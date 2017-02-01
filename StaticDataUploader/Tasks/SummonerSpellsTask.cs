using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.UploaderV2;
using CoffeeCat.RiotCommon.Settings;
using CoffeeCat.RiotCommon.Utils;

namespace CoffeeCat.StaticDataUploader.Tasks
{
    internal class SummonerSpellsTask : UploadTask
    {
        public SummonerSpellsTask(ApiVersion versions, UploaderSettings settings)
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
