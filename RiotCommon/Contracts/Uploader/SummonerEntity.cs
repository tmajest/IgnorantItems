using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace CoffeeCat.RiotCommon.Contracts.Uploader
{
    public class SummonerEntity : TableEntity
    {
        public string Id { get; set; }

        public string Region { get; set; }

        public string ProName { get; set; }

        public DateTime LastUpdated { get; set; }

        public SummonerEntity()
        {
        }

        public SummonerEntity(string proName, string summonerName, string region)
        {
            this.PartitionKey = summonerName;
            this.RowKey = summonerName;
            this.Region = region;
        }
    }
}
