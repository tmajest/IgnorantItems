using System;
using System.Collections.Generic;

namespace CoffeeCat.RiotCommon.Settings
{
    public class UploaderSettings : IUploaderSettings
    {
        public string AzureStorageConnectionString { get; set; }

        public List<string> RiotApiKeys { get; set; }

        public string Region { get; set;}

        public string DataContainerName { get; set; }

        public string ApiVersionsBlobPath { get; set; }

        public string SummonersTableName { get; set; }

        public string MatchListTableName { get; set; }

        public string MasteriesBlobPath { get; set; }

        public string RunesBlobPath { get; set; }

        public string ChampionsBlobPath { get; set; }

        public string ItemsBlobPath { get; set; }

        public string SummonerSpellsBlobPath { get; set; }

        public int Retries { get; set; }

        public TimeSpan Timeout { get; set; } 

        public TimeSpan MatchDetailRequestDelay { get; set; }

        public TimeSpan RetryDelay { get; set; }

        public TimeSpan RateLimitDelay { get; set; }

        public TimeSpan DefaultUploadPeriod { get; set; }
    }
}