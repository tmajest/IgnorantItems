using Newtonsoft.Json;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.Uploader;
using CoffeeCat.RiotCommon.Settings;
using CoffeeCat.RiotCommon.Utils;

namespace CoffeeCat.StaticDataUploader.Tasks
{
    internal class MasteriesUploadTask : UploadTask
    {
        public MasteriesUploadTask(ApiVersion versions, KeyManager keyManager, IUploaderSettings settings)
            : base(versions, keyManager, settings)
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
