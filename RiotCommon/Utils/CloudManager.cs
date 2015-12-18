using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace CoffeeCat.RiotCommon.Utils
{
    /// <summary>
    /// Class to manage Azure CloudBlobs and Azure CloudTables.
    /// </summary>
    public class CloudManager : ICloudManager
    {
        private string connectionString;

        /// <summary>
        /// Creates a new CloudManager with the given connection string.
        /// </summary>
        /// <param name="connectionString">The Azure storage connection string</param>
        public CloudManager(string connectionString)
        {
            Validation.ValidateNotNullOrWhitespace(connectionString, nameof(connectionString));
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Download the data from the given cloud blob as text.
        /// </summary>
        /// <param name="blobContainerName">The blob container name</param>
        /// <param name="blobName">The blob file name</param>
        /// <returns>A task whose result contains the blob's contents</returns>
        public Task<string> DownloadTextAsync(string blobContainerName, string blobName)
        {
            Validation.ValidateNotNullOrWhitespace(blobContainerName, nameof(blobContainerName));
            Validation.ValidateNotNullOrWhitespace(blobName, nameof(blobName));

            var storageAccount = CloudStorageAccount.Parse(this.connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            var blobContainer = blobClient.GetContainerReference(blobContainerName);
            return blobContainer.GetBlockBlobReference(blobName)?.DownloadTextAsync();
        }

        /// <summary>
        /// Uploads the text to the specified cloud blob.
        /// </summary>
        /// <param name="blobContainerName">The blob container name</param>
        /// <param name="blobName">The blob file name</param>
        /// <param name="text">The text to upload</param>
        public Task UploadTextAsync(string blobContainerName, string blobName, string text)
        {
            Validation.ValidateNotNullOrWhitespace(blobContainerName, nameof(blobContainerName));
            Validation.ValidateNotNullOrWhitespace(blobName, nameof(blobName));

            var storageAccount = CloudStorageAccount.Parse(this.connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            var blobContainer = blobClient.GetContainerReference(blobContainerName);
            return blobContainer.GetBlockBlobReference(blobName)?.UploadTextAsync(text);
        }

        /// <summary>
        /// Gets the CloudTable with the given table name.
        /// </summary>
        /// <param name="tableName">The cloud table name</param>
        /// <returns>The cloud table</returns>
        public CloudTable GetCloudTable(string tableName)
        {
            Validation.ValidateNotNullOrWhitespace(tableName, nameof(tableName));

            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            return tableClient.GetTableReference(tableName);
        }

        /// <summary>
        /// Gets all rows from the cloud table.
        /// </summary>
        /// <param name="tableName">The cloud table name</param>
        /// <returns>The cloud table</returns>
        public List<T> GetRows<T>(string tableName) where T : TableEntity, new()
        {
            var table = GetCloudTable(tableName);
            var query = new TableQuery<T>();
            return table.ExecuteQuery(query).ToList();
        }

        /// <summary>
        /// Gets all rows from the cloud table.
        /// </summary>
        /// <param name="entity">The entity to insert</param>
        /// <param name="tableName">The cloud table name</param>
        /// <returns>The cloud table</returns>
        public Task InsertOrReplace<T>(T entity, string tableName) where T : TableEntity, new()
        {
            var table = GetCloudTable(tableName);
            var tableOperation = TableOperation.InsertOrReplace(entity);
            return table.ExecuteAsync(tableOperation);
        }
    }
}
