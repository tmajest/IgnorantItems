using Newtonsoft.Json;
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
    internal class ItemsUploadTask : UploadTask
    {
        public ItemsUploadTask(ApiVersion versions, KeyManager keyManager, IUploaderSettings settings)
            : base(versions, keyManager, settings)
        {
        }

        protected override string BlobName => this.settings.ItemsBlobPath;

        protected override async Task<string> GetUploadData()
        {
            var items = await this.Client.GetItems();
            return JsonConvert.SerializeObject(items);
        }
    }
}
