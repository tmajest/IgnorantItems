using CoffeeCat.RiotCommon.Settings;
using CoffeeCat.RiotDatabase;
using CoffeeCat.RiotCommon.Contracts.Entities;
using CoffeeCat.StaticDataUploader.Tasks;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.StaticDataUploader
{
    internal class StaticDataUploader
    {
        private readonly CommonSettings settings;
        private readonly ApiVersion apiVersions;

        public StaticDataUploader(CommonSettings settings)
        {
            this.settings = settings;
            using (var context = new RiotContext(this.settings.DatabaseConnectionString))
            {
                this.apiVersions = Utils.GetApiVersion(context);
            }
        }

        public Task Run()
        {
            var uploadMasteriesTask = UploadMasteries();
            var uploadRunesTask = UploadRunes();
            var uploadChampionsTask = UploadChampions();
            var uploadItemsTask = UploadItems();
            var uploadSummonerSpellsTask = UploadSummonerSpells();

            return Task.WhenAll(
                uploadMasteriesTask, 
                uploadRunesTask, 
                uploadChampionsTask, 
                uploadItemsTask,
                uploadSummonerSpellsTask);
        }

        private async Task UploadMasteries()
        {
            Console.WriteLine("Begin uploading masteries");

            using (var masteryTask = new MasteriesUploadTask(this.apiVersions, this.settings))
            {
                await masteryTask.UploadData();
            }

            Console.WriteLine("Completed uploading masteries.");
        }

        private async Task UploadRunes()
        {
            Console.WriteLine("Begin uploading masteries");

            using (var runesTask = new RunesUploadTask(this.apiVersions, this.settings))
            {
                await runesTask.UploadData();
            }

            Console.WriteLine("Completed uploading runes.");
        }

        private async Task UploadChampions()
        {
            Console.WriteLine("Begin uploading champions");

            using (var championsTask = new ChampionsUploadTask(this.apiVersions, this.settings))
            {
                await championsTask.UploadData();
            }

            Console.WriteLine("Completed uploading champions.");
        }

        private async Task UploadItems()
        {
            Console.WriteLine("Begin uploading items");

            using (var itemsTask = new ItemsUploadTask(this.apiVersions, this.settings))
            {
                await itemsTask.UploadData();
            }

            Console.WriteLine("Completed uploading items.");
        }

        private async Task UploadSummonerSpells()
        {
            Console.WriteLine("Begin uploading summoner spells");

            using (var summonerSpellsTask = new SummonerSpellsTask(this.apiVersions, this.settings))
            {
                await summonerSpellsTask.UploadData();
            }

            Console.WriteLine("Completed uploading summoner spells.");
        }
    }
}
