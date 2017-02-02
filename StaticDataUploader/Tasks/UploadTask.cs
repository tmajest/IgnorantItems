using CoffeeCat.RiotClient.Clients;
using CoffeeCat.RiotCommon.Contracts.Entities;
using CoffeeCat.RiotCommon.Settings;
using CoffeeCat.RiotCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.StaticDataUploader.Tasks
{
    internal abstract class UploadTask : IDisposable
    {
        private readonly CloudManager cloudManager;

        protected StaticDataClient Client { get; }
        protected readonly CommonSettings settings;

        protected UploadTask(ApiVersion versions, CommonSettings settings)
        {
            Validation.ValidateNotNull(versions, nameof(versions));
            Validation.ValidateNotNull(settings, nameof(settings));

            this.cloudManager = new CloudManager(settings.StorageConnectionString);
            this.settings = settings;
            this.Client = new StaticDataClient(settings.Region, versions.StaticDataVersion, this.settings.RiotApiKey);
        }

        protected abstract Task<string> GetUploadData();

        protected abstract string BlobName { get; }

        public async Task UploadData()
        {
            var data = await this.GetUploadData();
            await this.cloudManager.UploadTextAsync(this.settings.StaticDataContainerName, this.BlobName, data);
        }

        public void Dispose()
        {
            this.Client.Dispose();
        }
    }
}
