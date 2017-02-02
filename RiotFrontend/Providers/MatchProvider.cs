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
        private static readonly int DefaultMatchCount = 15;

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

        public Task<List<Match>> GetMatches()
        {
            return this.GetMatches(DefaultMatchCount);
        }

        public async Task<List<Match>> GetMatches(int count)
        {
            using (var context = new RiotContext(this.settings.DatabaseConnectionString))
            {
                var matchEntities = await context.Matches
                    .OrderByDescending(m => m.CreationTime)
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

                return convertedMatches;
            }
        }

        public Task<List<Match>> GetMatchesByChampion(int championId)
        {
            return this.GetMatchesByChampion(championId, DefaultMatchCount);
        }

        public async Task<List<Match>> GetMatchesByChampion(int championId, int count)
        {
            using (var context = new RiotContext(this.settings.DatabaseConnectionString))
            {
                var participants = await context.Participants
                    .Where(p => p.ChampionId == championId && p.Summoner != null)
                    .Select(p => new {Participant = p, Match = p.Match})
                    .OrderByDescending(p => p.Match.CreationTime)
                    .Take(count)
                    .ToListAsync();

                return participants
                    .Select(p => dtoConverter.GetMatchContract(p.Match, p.Participant, FormatType.Simple))
                    .ToList();
            }

        }
    }
}