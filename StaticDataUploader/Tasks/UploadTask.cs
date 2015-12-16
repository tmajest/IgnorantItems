using CoffeeCat.RiotClient.Clients;
using CoffeeCat.RiotCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.Uploader;
using CoffeeCat.RiotCommon.Settings;

namespace CoffeeCat.StaticDataUploader.Tasks
{
    internal abstract class UploadTask : IDisposable
    {
        private CloudManager cloudManager;

        protected StaticDataClient Client { get; private set; }
        protected IUploaderSettings settings;

        public UploadTask(ApiVersion versions, KeyManager keyManager, IUploaderSettings settings)
        {
            Validation.ValidateNotNull(versions, nameof(versions));
            Validation.ValidateNotNull(keyManager, nameof(keyManager));
            Validation.ValidateNotNull(settings, nameof(settings));

            this.settings = settings;
            this.cloudManager = new CloudManager(settings.AzureStorageConnectionString);
            this.Client = new StaticDataClient(settings.Region, versions.StaticDataVersion, keyManager.NextKey);
        }

        protected abstract Task<string> GetUploadData();

        protected abstract string BlobName { get; }

        public async Task UploadData()
        {
            var data = await this.GetUploadData();
            await this.cloudManager.UploadTextAsync(this.settings.DataContainerName, this.BlobName, data);
        }

        public void Dispose()
        {
            this.Client.Dispose();
        }
    }
}
