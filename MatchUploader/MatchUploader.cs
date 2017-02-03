using CoffeeCat.RiotClient.Clients;
using CoffeeCat.RiotCommon.Utils;
using CoffeeCat.MatchUploader.Converters;
using CoffeeCat.RiotCommon.Contracts.Entities;
using CoffeeCat.RiotCommon.Settings;
using CoffeeCat.RiotDatabase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.RiotApi.Match;

namespace CoffeeCat.MatchUploader
{
    internal class MatchUploader
    {
        private readonly ICommonSettings settings;

        public MatchUploader(ICommonSettings settings)
        {
            Validation.ValidateNotNull(settings, nameof(settings));
            this.settings = settings;
        }

        public async Task Run()
        {
            using (var context = new RiotContext(settings.DatabaseConnectionString))
            {
                var versions = Utils.GetApiVersion(context);
                foreach (var streamer in context.Streamers.ToList())
                {
                    foreach (var summoner in streamer.Summoners.ToList())
                    {
                        await this.UploadMatchHistory(summoner, versions, context);
                    }
                }
            }
        }

        private async Task UploadMatchHistory(SummonerEntity summoner, ApiVersion version, RiotContext context)
        {
            Console.WriteLine("Getting match history for summoner " + summoner.Name + "...");
            var beginTime = summoner.LastUpdatedTime;
            var endTime = DateTime.UtcNow;
            if (beginTime > endTime || beginTime == DateTime.MinValue)
            {
                beginTime = DateTime.UtcNow.Subtract(settings.DefaultUploadPeriod);    
            }

            var matches = await GetMatchList(summoner, version, beginTime, endTime);
            if (matches == null)
            {
                Console.WriteLine($"Finished getting {summoner.Name} match history");
                return;
            }

            foreach (var matchReference in matches)
            {
                var matchEntity = context.Matches.FirstOrDefault(m => m.Id == matchReference.MatchId);
                if (matchEntity != null)
                {
                    continue;
                }

                var matchDetails = await GetMatchDetail(matchReference, version);

                // Match doesn't exist, create it
                matchEntity = MatchConverter.GetMatchEntity(matchDetails, matchReference, summoner);
                context.Matches.Add(matchEntity);

                // Create participants
                foreach (var participant in ParticipantConverter.GetParticipants(matchDetails, context))
                {
                    participant.Match = matchEntity;
                    context.Participants.Add(participant);
                }
            }

            // Update the summoner's last updated time
            summoner.LastUpdatedTime = endTime;
            await context.SaveChangesAsync();

            Console.WriteLine($"Finished getting {summoner.Name} match history");
        }

        private async Task<MatchDetailDto> GetMatchDetail(MatchReferenceDto matchReference, ApiVersion versions)
        {
            var region = matchReference.Region.ToLowerInvariant();
            for (var i = 0; i < settings.Retries - 1; i++)
            {
                try
                {
                    using (var client = new MatchDetailClient(region, versions.MatchVersion, this.settings.RiotApiKey))
                    {
                        return await client.GetMatchDetails(matchReference.MatchId.ToString());
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Hit rate limit, retrying {0}...", i);
                }

                await Task.Delay(settings.RetryDelay);
            }

            Console.WriteLine("Hit rate limit. Waiting...");
            await Task.Delay(settings.RateLimitDelay);
            using (var client = new MatchDetailClient(region, versions.MatchVersion, this.settings.RiotApiKey))
            {
                return await client.GetMatchDetails(matchReference.MatchId.ToString());
            }
        }

        private async Task<List<MatchReferenceDto>> GetMatchList(
            SummonerEntity summoner, 
            ApiVersion versions, 
            DateTime beginTime, 
            DateTime endTime)
        {
            try
            {
                using (var matchListClient = new MatchListClient(summoner.Region, versions.MatchListVersion, this.settings.RiotApiKey))
                {
                    var matchReferences = await matchListClient.GetMatchList(summoner.Id.ToString(), beginTime, endTime);
                    return matchReferences.Matches;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
