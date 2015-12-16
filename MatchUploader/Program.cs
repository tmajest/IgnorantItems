using System;
using System.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Settings;

namespace CoffeeCat.MatchUploader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IUploaderSettings settings;
            try
            {
                settings = GetUploaderSettings();
            }
            catch (Exception e)
            {
                Trace.TraceError("Could not configure MatchUploader: {0}", e);
                return;
            }

            try
            {
                Trace.TraceInformation("Starting MatchUploader...");

                var matchUploader = new MatchUploader(settings);
                if (matchUploader.Run().Wait(settings.Timeout))
                {
                    Trace.TraceInformation("MatchUploader completed successfully");
                }
                else
                {
                    Trace.TraceError("MatchUploader timed out before it could complete.");
                }

            }
            catch (AggregateException e)
            {
                Trace.TraceError("MatchUploader failed with error: " + e.InnerException);
            }
        }

        private static IUploaderSettings GetUploaderSettings()
        {
            var appSettings = ConfigurationManager.AppSettings;
            return new UploaderSettings()
            {
                AzureStorageConnectionString = appSettings["AzureStorageConnectionString"],
                RiotApiKeys = appSettings["ApiKeys"].Split(',').ToList(),
                Retries = int.Parse(appSettings["Retries"]),
                Region = appSettings["Region"],
                DataContainerName = appSettings["DataContainerName"],
                ApiVersionsBlobPath = appSettings["ApiVersionsBlobPath"],
                SummonersTableName = appSettings["SummonersTableName"],
                MatchListTableName = appSettings["MatchListTableName"],
                Timeout = TimeSpan.FromSeconds(long.Parse(appSettings["UploadTimeoutInSeconds"])),
                MatchDetailRequestDelay = TimeSpan.FromSeconds(int.Parse(appSettings["MatchDetailRequestDelaySeconds"])),
                RetryDelay = TimeSpan.FromSeconds(int.Parse(appSettings["RetryDelaySeconds"])),
                RateLimitDelay = TimeSpan.FromMinutes(int.Parse(appSettings["RateLimitDelayMinutes"])),
                DefaultUploadPeriod = TimeSpan.FromDays(int.Parse(appSettings["DefaultUploadPeriodDays"])),
            };
        }
    }
}
