using System;
using System.Collections.Generic;

namespace CoffeeCat.RiotCommon.Settings
{
    public class UploaderSettings : IUploaderSettings
    {
        public string StorageConnectionString { get; set; }

        public string DatabaseConnectionString { get; set; }

        public string RiotApiKey { get; set; }

        public string Region { get; set;}

        public int Retries { get; set; }

        public string StorageAccountName { get; set; }

        public string StaticDataContainerName { get; set; }

        public string ChampionsBlobPath { get; set; }

        public string ItemsBlobPath { get; set; }

        public string MasteriesBlobPath { get; set; }

        public string RunesBlobPath { get; set; }

        public string SummonerSpellsBlobPath { get; set; }

        public TimeSpan Timeout { get; set; } 

        public TimeSpan MatchDetailRequestDelay { get; set; }

        public TimeSpan RetryDelay { get; set; }

        public TimeSpan RateLimitDelay { get; set; }

        public TimeSpan DefaultUploadPeriod { get; set; }
    }
}