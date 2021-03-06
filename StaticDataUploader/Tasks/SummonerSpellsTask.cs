﻿using CoffeeCat.RiotCommon.Contracts.Entities;
using CoffeeCat.RiotCommon.Settings;
using CoffeeCat.RiotCommon.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.StaticDataUploader.Tasks
{
    internal class SummonerSpellsTask : UploadTask
    {
        public SummonerSpellsTask(ApiVersion versions, CommonSettings settings)
            : base(versions, settings)
        {
        }

        protected override string BlobName => this.settings.SummonerSpellsBlobPath;

        protected override async Task<string> GetUploadData()
        {
            var summonerSpells = await this.Client.GetSummonerSpells();
            return JsonConvert.SerializeObject(summonerSpells);
        }
    }
}
