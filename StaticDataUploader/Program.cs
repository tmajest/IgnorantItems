using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Settings;

namespace CoffeeCat.StaticDataUploader
{
    class Program
    {
        public static void Main(string[] args)
        {
            var appSettings = ConfigurationManager.AppSettings;
            var settings = new UploaderSettings()
            {
                StorageAccountName = appSettings["StorageAccountName"],
                StaticDataContainerName = appSettings["StaticDataContainerName"],
                DatabaseConnectionString = appSettings["DatabaseConnectionString"],
                StorageConnectionString = appSettings["StorageConnectionString"],
                ChampionsBlobPath = appSettings["ChampionsBlobPath"],
                ItemsBlobPath = appSettings["ItemsBlobPath"],
                MasteriesBlobPath = appSettings["MasteriesBlobPath"],
                RunesBlobPath = appSettings["RunesBlobPath"],
                SummonerSpellsBlobPath = appSettings["SummonerSpellsBlobPath"],
                RiotApiKey = appSettings["ApiKey"],
                Retries = int.Parse(appSettings["Retries"]),
                Region = appSettings["Region"],
                Timeout = TimeSpan.FromSeconds(long.Parse(appSettings["UploadTimeoutInSeconds"])),
                MatchDetailRequestDelay = TimeSpan.FromSeconds(int.Parse(appSettings["MatchDetailRequestDelaySeconds"])),
                RetryDelay = TimeSpan.FromSeconds(int.Parse(appSettings["RetryDelaySeconds"])),
                RateLimitDelay = TimeSpan.FromMinutes(int.Parse(appSettings["RateLimitDelayMinutes"])),
                DefaultUploadPeriod = TimeSpan.FromDays(int.Parse(appSettings["DefaultUploadPeriodDays"])),
            };

            var staticDataUploader = new StaticDataUploader(settings);

            try
            {
                Trace.TraceInformation("Starting StaticDataUploader...");
                if (staticDataUploader.Run().Wait(settings.Timeout))
                {
                    Trace.TraceInformation("StaticDataUploader completed successfully");
                }
                else
                {
                    Trace.TraceError("StaticDataUploader timed out before it could complete.");
                }

            }
            catch (AggregateException e)
            {
                Trace.TraceError("StaticDataUploader failed with error: " + e.InnerException);
            }
        }
    }
}
