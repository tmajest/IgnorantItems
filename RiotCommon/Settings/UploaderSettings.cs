using System;
using System.Collections.Generic;

namespace CoffeeCat.RiotCommon.Settings
{
    public class UploaderSettings : IUploaderSettings
    {
        public string ConnectionString { get; set; }

        public string RiotApiKey { get; set; }

        public string Region { get; set;}

        public int Retries { get; set; }

        public TimeSpan Timeout { get; set; } 

        public TimeSpan MatchDetailRequestDelay { get; set; }

        public TimeSpan RetryDelay { get; set; }

        public TimeSpan RateLimitDelay { get; set; }

        public TimeSpan DefaultUploadPeriod { get; set; }
    }
}