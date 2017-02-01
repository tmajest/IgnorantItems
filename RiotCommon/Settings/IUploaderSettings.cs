using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace CoffeeCat.RiotCommon.Settings
{
    [InheritedExport(typeof(IUploaderSettings))]
    public interface IUploaderSettings
    {
        string DatabaseConnectionString { get; }

        string StorageConnectionString { get; }

        string RiotApiKey { get; }

        string Region { get; }

        int Retries { get; }

        TimeSpan Timeout { get; } 

        TimeSpan MatchDetailRequestDelay { get; }

        TimeSpan RetryDelay { get; }

        TimeSpan RateLimitDelay { get; }

        TimeSpan DefaultUploadPeriod { get; }
    }
}