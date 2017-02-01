using CoffeeCat.RiotCommon.Contracts.Entities;
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
    internal class RunesUploadTask : UploadTask
    {
        public RunesUploadTask(ApiVersion versions, UploaderSettings settings)
            : base(versions, settings)
        {
        }

        protected override string BlobName => this.settings.RunesBlobPath;

        protected override async Task<string> GetUploadData()
        {
            var runes = await this.Client.GetRunes();
            return JsonConvert.SerializeObject(runes);
        }
    }
}
