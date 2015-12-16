using CoffeeCat.RiotCommon.Contracts.Uploader;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Utils
{
    /// <summary>
    /// Class for managing Riot API Version strings.
    /// </summary>
    public class VersionManager
    {
        private CloudManager cloudManager;

        /// <summary>
        /// Creates a new VersionManager.
        /// </summary>
        /// <param name="azureConnectionString">The azure storage connection string</param>
        /// <param name="versionContainer">The container where the version blob lives</param>
        /// <param name="versionBlobPath">The version file blob name</param>
        public VersionManager(string azureConnectionString, string versionContainer, string versionBlobPath)
        {
            Validation.ValidateNotNullOrWhitespace(azureConnectionString, nameof(azureConnectionString));
            Validation.ValidateNotNullOrWhitespace(versionContainer, nameof(versionContainer));
            Validation.ValidateNotNullOrWhitespace(versionBlobPath, nameof(versionBlobPath));

            this.cloudManager = new CloudManager(azureConnectionString);

            var versionsJson = this.cloudManager.DownloadTextAsync(versionContainer, versionBlobPath).Result;
            this.Versions = JsonConvert.DeserializeObject<ApiVersion>(versionsJson);
        }

        /// <summary>
        /// Returns the Riot ApiVersion.
        /// </summary>
        public ApiVersion Versions { get; private set; }
    }
}
