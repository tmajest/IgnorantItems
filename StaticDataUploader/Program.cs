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
                AzureStorageConnectionString = appSettings["AzureStorageConnectionString"],
                RiotApiKeys = appSettings["ApiKeys"].Split(',').ToList(),
                Region = appSettings["Region"],
                DataContainerName = appSettings["DataContainerName"],
                MasteriesBlobPath = appSettings["MasteriesBlobPath"],
                RunesBlobPath = appSettings["RunesBlobPath"],
                ChampionsBlobPath = appSettings["ChampionsBlobPath"],
                ItemsBlobPath = appSettings["ItemsBlobPath"],
                ApiVersionsBlobPath = appSettings["ApiVersionsBlobPath"],
                Timeout = TimeSpan.FromSeconds(long.Parse(appSettings["UploadTimeoutInSeconds"]))
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
