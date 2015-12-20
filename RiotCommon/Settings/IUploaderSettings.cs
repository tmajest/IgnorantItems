using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace CoffeeCat.RiotCommon.Settings
{
    [InheritedExport(typeof(IUploaderSettings))]
    public interface IUploaderSettings
    {
        string AzureStorageConnectionString { get; }

        List<string> RiotApiKeys { get; }

        string Region { get; }

        string DataContainerName { get; }

        string ApiVersionsBlobPath { get; }

        string SummonersTableName { get; }

        string MatchListTableName { get; }

        string MasteriesBlobPath { get; }

        string RunesBlobPath { get; }

        string ChampionsBlobPath { get; }

        string ItemsBlobPath { get; }

        string SummonerSpellsBlobPath { get; }

        int Retries { get; }

        TimeSpan Timeout { get; } 

        TimeSpan MatchDetailRequestDelay { get; }

        TimeSpan RetryDelay { get; }

        TimeSpan RateLimitDelay { get; }

        TimeSpan DefaultUploadPeriod { get; }
    }
}