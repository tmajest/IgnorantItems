using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.Entities;
using CoffeeCat.RiotCommon.Settings;
using CoffeeCat.RiotCommon.Utils;
using CoffeeCat.RiotDatabase;
using CoffeeCat.RiotFrontend.BusinessLogic.Formatter;
using CoffeeCat.RiotFrontend.Models;
using Newtonsoft.Json;
using CoffeeCat.RiotFrontend.BusinessLogic.Converters;

namespace CoffeeCat.RiotFrontend.Providers
{
    public class MatchProvider : IMatchProvider
    {
        private ICommonSettings settings;
        private IDtoConverter dtoConverter;

        public MatchProvider(
            IDtoConverter dtoConverter,
            ICommonSettings settings)
        {
            this.dtoConverter = dtoConverter;
            this.settings = settings;
        }

        public async Task<Match> GetMatch(string proName, long matchId)
        {
            using (var context = new RiotContext(this.settings.DatabaseConnectionString))
            {
                var matchEntity = await context.Matches.FirstOrDefaultAsync(m => m.Id == matchId);
                if (matchEntity == null)
                {
                    return null;
                }

                var participant = matchEntity.Participants
                    .FirstOrDefault(p => p.Summoner != null && p.Summoner.Streamer.ProName.Equals(proName)); 

                return participant == null 
                    ? null 
                    : dtoConverter.GetMatchContract(matchEntity, participant, FormatType.Detailed);
            }
        }

        public async Task<MatchList> GetMatches(int skip, int count)
        {
            using (var context = new RiotContext(this.settings.DatabaseConnectionString))
            {
                var total = await context.Matches.CountAsync();

                var matchEntities = await context.Matches
                    .OrderByDescending(m => m.CreationTime)
                    .Skip(skip)
                    .Take(count)
                    .ToListAsync();

                var convertedMatches = new List<Match>();
                foreach (var matchEntity in matchEntities)
                {
                    foreach (var participant in matchEntity.Participants.Where(p => p.Summoner != null))
                    {
                        convertedMatches.Add(dtoConverter.GetMatchContract(matchEntity, participant, FormatType.Simple));
                    }
                }

                return new MatchList { Matches = convertedMatches, Total = total };
            }
        }

        public async Task<MatchList> GetMatchesByChampion(int championId, int skip, int count)
        {
            using (var context = new RiotContext(this.settings.DatabaseConnectionString))
            {
                var participants = context.Participants
                    .Where(p => p.ChampionId == championId && p.Summoner != null)
                    .Select(p => new { Participant = p, Match = p.Match });

                var total = await participants.CountAsync();
                var matches = await participants
                    .OrderByDescending(p => p.Match.CreationTime)
                    .Skip(skip)
                    .Take(count)
                    .ToListAsync();

                var convertedMatches = matches.Select(p => dtoConverter.GetMatchContract(p.Match, p.Participant, FormatType.Simple))
                    .ToList();

                return new MatchList { Matches = convertedMatches, Total = total };
            }
        }
    }
}