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
    internal class MasteriesUploadTask : UploadTask
    {
        public MasteriesUploadTask(ApiVersion versions, UploaderSettings settings)
            : base(versions, settings)
        {
        }

        protected override string BlobName => this.settings.MasteriesBlobPath;

        protected override async Task<string> GetUploadData()
        {
            var masteries = await this.Client.GetMasteries();
            return JsonConvert.SerializeObject(masteries);
        }
    }
}
