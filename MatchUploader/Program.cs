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
                Console.WriteLine($"Could not configure MatchUploader: {e}");
                return;
            }

            try
            {
                Console.WriteLine("Starting MatchUploader...");

                var matchUploader = new MatchUploader(settings);
                if (matchUploader.Run().Wait(settings.Timeout))
                {
                    Console.WriteLine("MatchUploader completed successfully");
                }
                else
                {
                    Console.WriteLine("MatchUploader timed out before it could complete.");
                }
            }
            catch (AggregateException e)
            {
                Console.WriteLine($"MatchUploader failed with error: {e.InnerException}");
            }
        }

        private static IUploaderSettings GetUploaderSettings()
        {
            var appSettings = ConfigurationManager.AppSettings;
            return new UploaderSettings
            {
                DatabaseConnectionString = appSettings["DatabaseConnectionString"],
                StorageConnectionString = appSettings["StorageConnectionString"],
                RiotApiKey = appSettings["ApiKey"],
                Retries = int.Parse(appSettings["Retries"]),
                Region = appSettings["Region"],
                Timeout = TimeSpan.FromSeconds(long.Parse(appSettings["UploadTimeoutInSeconds"])),
                MatchDetailRequestDelay = TimeSpan.FromSeconds(double.Parse(appSettings["MatchDetailRequestDelaySeconds"])),
                RetryDelay = TimeSpan.FromSeconds(double.Parse(appSettings["RetryDelaySeconds"])),
                RateLimitDelay = TimeSpan.FromMinutes(double.Parse(appSettings["RateLimitDelayMinutes"])),
                DefaultUploadPeriod = TimeSpan.FromDays(double.Parse(appSettings["DefaultUploadPeriodDays"])),
            };
        }
    }
}
