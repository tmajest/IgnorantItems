using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace CoffeeCat.RiotCommon.Utils
{
    public interface ICloudManager
    {
        /// <summary>
        /// Download the data from the given cloud blob as text.
        /// </summary>
        /// <param name="blobContainerName">The blob container name</param>
        /// <param name="blobName">The blob file name</param>
        /// <returns>A task whose result contains the blob's contents</returns>
        Task<string> DownloadTextAsync(string blobContainerName, string blobName);

        /// <summary>
        /// Uploads the text to the specified cloud blob.
        /// </summary>
        /// <param name="blobContainerName">The blob container name</param>
        /// <param name="blobName">The blob file name</param>
        /// <param name="text">The text to upload</param>
        Task UploadTextAsync(string blobContainerName, string blobName, string text);

        /// <summary>
        /// Gets the CloudTable with the given table name.
        /// </summary>
        /// <param name="tableName">The cloud table name</param>
        /// <returns>The cloud table</returns>
        CloudTable GetCloudTable(string tableName);

        /// <summary>
        /// Gets all rows from the cloud table.
        /// </summary>
        /// <param name="tableName">The cloud table name</param>
        /// <returns>The cloud table</returns>
        List<T> GetRows<T>(string tableName) where T : TableEntity, new();

        /// <summary>
        /// Gets all rows from the cloud table.
        /// </summary>
        /// <param name="entity">The entity to insert</param>
        /// <param name="tableName">The cloud table name</param>
        /// <returns>The cloud table</returns>
        Task InsertOrReplace<T>(T entity, string tableName) where T : TableEntity, new();
    }
}
