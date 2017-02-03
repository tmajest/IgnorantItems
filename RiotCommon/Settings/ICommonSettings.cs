using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace CoffeeCat.RiotCommon.Settings
{
    [InheritedExport(typeof(ICommonSettings))]
    public interface ICommonSettings
    {
        string DatabaseConnectionString { get; }

        string StorageConnectionString { get; }

        string RiotApiKey { get; }

        string Region { get; }

        int Retries { get; }

        string StaticDataContainerName { get; }

        string ChampionsBlobPath { get; }

        string ItemsBlobPath { get; }

        string MasteriesBlobPath { get; }

        string RunesBlobPath { get; }

        string SummonerSpellsBlobPath { get; }

        TimeSpan Timeout { get; } 

        TimeSpan MatchDetailRequestDelay { get; }

        TimeSpan RetryDelay { get; }

        TimeSpan RateLimitDelay { get; }

        TimeSpan DefaultUploadPeriod { get; }

        TimeSpan StaticDataRefreshRate { get; }
    }
}