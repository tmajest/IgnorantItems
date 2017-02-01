using CoffeeCat.RiotClient.Clients;
using CoffeeCat.RiotCommon.Dto.Match;
using CoffeeCat.RiotCommon.Utils;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.MatchUploader.Converters;
using CoffeeCat.RiotCommon.Contracts.UploaderV2;
using CoffeeCat.RiotCommon.Settings;
using Microsoft.WindowsAzure.Storage.Table;
using RiotDatabase;

namespace CoffeeCat.MatchUploader
{
    class MatchUploader
    {
        private IUploaderSettings settings;

        public MatchUploader(IUploaderSettings settings)
        {
            Validation.ValidateNotNull(settings, nameof(settings));
            this.settings = settings;
        }

        public async Task Run()
        {
            using (var context = new RiotContext(settings.ConnectionString))
            {
                var versions = Utils.GetApiVersion(context);
                foreach (var streamer in context.Streamers)
                {
                    foreach (var summoner in streamer.Summoners)
                    {
                        await this.UploadMatchHistory(summoner, versions);
                    }
                }
            }
        }

        private async Task UploadMatchHistory(SummonerEntity summoner, ApiVersion version)
        {
            Trace.WriteLine("Getting match history for summoner " + summoner.Name + "...");
            var beginTime = summoner.LastUpdatedTime;
            var endTime = DateTime.UtcNow;
            if (beginTime > endTime || beginTime == DateTime.MinValue)
            {
                beginTime = DateTime.UtcNow.Subtract(settings.DefaultUploadPeriod);    
            }

            var matches = await GetMatchList(summoner, version, beginTime, endTime);
            if (matches == null)
            {
                Trace.TraceInformation($"Finished getting {summoner.Name} match history");
                return;
            }

            using (var context = new RiotContext(this.settings.ConnectionString))
            {
                foreach (var matchReference in matches)
                {
                    var matchDetails = await GetMatchDetail(matchReference, version);

                    // Create match
                    var matchEntity = MatchConverter.GetMatchEntity(matchDetails, matchReference, summoner);
                    context.Matches.Add(matchEntity);
                    context.SaveChanges();

                    // Create participants
                    foreach (var participant in ParticipantConverter.GetParticipants(matchDetails, context))
                    {
                        participant.Match = matchEntity;
                        context.Participants.Add(participant);
                        await context.SaveChangesAsync();
                    }

                    // Wait between match details requests to avoid hitting rate limit
                    await Task.Delay(settings.MatchDetailRequestDelay);
                }

                // Update the summoner's last updated time
                summoner.LastUpdatedTime = endTime;
                context.SaveChanges();
            }

            Trace.TraceInformation($"Finished getting {summoner.Name} match history");
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
                    Trace.TraceWarning("Hit rate limit, retrying {0}...", i);
                }

                await Task.Delay(settings.RetryDelay);
            }

            Trace.TraceWarning("Hit rate limit. Waiting...");
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
