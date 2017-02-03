using CoffeeCat.RiotCommon.Contracts.Entities;
using CoffeeCat.RiotCommon.Settings;
using CoffeeCat.RiotCommon.Utils;
using Newtonsoft.Json;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.StaticDataUploader.Tasks
{
    internal class ChampionsUploadTask : UploadTask
    {
        public ChampionsUploadTask(ApiVersion versions, CommonSettings settings)
            : base(versions, settings)
        {
        }

        protected override string BlobName => this.settings.ChampionsBlobPath;

        protected override async Task<string> GetUploadData()
        {
            var champions = await this.Client.GetChampions();
            return JsonConvert.SerializeObject(champions);
        }
    }
}
