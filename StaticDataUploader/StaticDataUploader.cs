﻿using CoffeeCat.RiotClient.Clients;
using CoffeeCat.RiotCommon.Utils;
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
using CoffeeCat.RiotCommon.Settings;

namespace CoffeeCat.StaticDataUploader
{
    internal class StaticDataUploader
    {
        private readonly IUploaderSettings settings;
        private readonly KeyManager keyManager;

        public StaticDataUploader(IUploaderSettings settings)
        {
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
            Trace.WriteLine("Begin uploading masteries");

            /*
            using (var masteryTask = new MasteriesUploadTask(this.versionManager.Versions, this.keyManager, this.settings))
            {
                await masteryTask.UploadData();
            }
            */

            Trace.WriteLine("Completed uploading masteries.");
        }

        private async Task UploadRunes()
        {
            Trace.WriteLine("Begin uploading masteries");

            /*
            using (var runesTask = new RunesUploadTask(this.versionManager.Versions, this.keyManager, this.settings))
            {
                await runesTask.UploadData();
            }

            Trace.WriteLine("Completed uploading runes.");
            */
        }

        private async Task UploadChampions()
        {
            /*
            Trace.WriteLine("Begin uploading champions");

            using (var championsTask = new ChampionsUploadTask(this.versionManager.Versions, this.keyManager, this.settings))
            {
                await championsTask.UploadData();
            }
            */

            Trace.WriteLine("Completed uploading champions.");
        }

        private async Task UploadItems()
        {
            Trace.WriteLine("Begin uploading items");

            /*
            using (var itemsTask = new ItemsUploadTask(this.versionManager.Versions, this.keyManager, this.settings))
            {
                await itemsTask.UploadData();
            }
            */

            Trace.WriteLine("Completed uploading items.");
        }

        private async Task UploadSummonerSpells()
        {
            Trace.WriteLine("Begin uploading summoner spells");
            /*

            using (var summonerSpellsTask = new SummonerSpellsTask(this.versionManager.Versions, this.keyManager, this.settings))
            {
                await summonerSpellsTask.UploadData();
            }
            */

            Trace.WriteLine("Completed uploading summoner spells.");
        }
    }
}
