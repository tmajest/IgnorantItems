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
using CoffeeCat.RiotCommon.Contracts.Uploader;
using CoffeeCat.RiotCommon.Settings;
using Microsoft.WindowsAzure.Storage.Table;

namespace CoffeeCat.MatchUploader
{
    class MatchUploader
    {
        private IUploaderSettings settings;
        private CloudManager cloudManager;
        private KeyManager keyManager;
        private VersionManager versionManager;

        public MatchUploader(IUploaderSettings settings)
        {
            Validation.ValidateNotNull(settings, nameof(settings));
            Validation.ValidateNotNullOrWhitespace(settings.AzureStorageConnectionString, "AzureStorageConnectionString");
            Validation.ValidateNotNullOrWhitespace(settings.DataContainerName, "DataContainerName");
            Validation.ValidateNotNullOrWhitespace(settings.Region, "Region");
            Validation.ValidateNotNullOrEmpty(settings.RiotApiKeys, "RiotApiKey");
            Validation.ValidateNotNullOrWhitespace(settings.SummonersTableName, "SummonersTableName");
            Validation.ValidateNotNullOrWhitespace(settings.ApiVersionsBlobPath, "ApiVersionsBlobPath");

            this.settings = settings;
            this.cloudManager = new CloudManager(settings.AzureStorageConnectionString);
            this.keyManager = new KeyManager(settings.RiotApiKeys);
            this.versionManager = new VersionManager(
                settings.AzureStorageConnectionString, 
                settings.DataContainerName, 
                settings.ApiVersionsBlobPath);
        }

        public async Task Run()
        {
            var summonerList = cloudManager.GetRows<SummonerEntity>(this.settings.SummonersTableName);
            foreach (var summoner in summonerList)
            {
                await UploadMatchHistory(summoner, versionManager.Versions);                
            }
        }

        private async Task UploadMatchHistory(SummonerEntity summoner, ApiVersion versions)
        {
            Trace.WriteLine("Getting match history for summoner " + summoner.ProName + "...");
            var beginTime = summoner.LastUpdated;
            var endTime = DateTime.UtcNow;
            if (beginTime > endTime || beginTime == DateTime.MinValue)
            {
                beginTime = DateTime.UtcNow.Subtract(settings.DefaultUploadPeriod);    
            }

            var matches = await GetMatchList(summoner, versions, beginTime, endTime);
            if (matches == null)
            {
                Trace.TraceInformation("Finished getting {0} match history", summoner.ProName);
                return;
            }

            foreach (var match in matches)
            {
                var matchDetails = await GetMatchDetail(match, versions);
                var matchEntity = MatchConverter.GetMatchEntity(matchDetails, match, summoner);
                await cloudManager.InsertOrReplace(matchEntity, this.settings.MatchListTableName);
                
                // Wait between match details requests to avoid hitting rate limit
                await Task.Delay(settings.MatchDetailRequestDelay);
            }

            // Update the summoner's last updated time
            summoner.LastUpdated = endTime;
            await this.cloudManager.InsertOrReplace(summoner, this.settings.SummonersTableName);

            Trace.TraceInformation("Finished getting {0} match history", summoner.ProName);
        }

        private async Task<MatchDetailDto> GetMatchDetail(MatchReferenceDto matchReference, ApiVersion versions)
        {
            var region = matchReference.Region.ToLowerInvariant();
            for (var i = 0; i < settings.Retries - 1; i++)
            {
                try
                {
                    using (var client = new MatchDetailClient(region, versions.MatchVersion, this.keyManager.NextKey))
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
            using (var client = new MatchDetailClient(region, versions.MatchVersion, this.keyManager.NextKey))
            {
                return await client.GetMatchDetails(matchReference.MatchId.ToString());
            }
        }

        private async Task<List<MatchReferenceDto>> GetMatchList(SummonerEntity summoner, ApiVersion versions, DateTime beginTime, DateTime endTime)
        {
            try
            {
                using (var matchListClient = new MatchListClient(summoner.Region, versions.MatchListVersion, this.keyManager.NextKey))
                {
                    var matchReferences = await matchListClient.GetMatchList(summoner.Id, beginTime, endTime);
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
