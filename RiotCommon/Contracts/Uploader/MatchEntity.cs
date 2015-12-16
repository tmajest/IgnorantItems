using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace CoffeeCat.RiotCommon.Contracts.Uploader
{
    public class MatchEntity : TableEntity
    {
        public string Match { get; set; }
        public string ChampionId { get; set; }
        public DateTime MatchCreationTime { get; set; }

        public MatchEntity(string summonerName, string matchId, string championId, DateTime creationTime, string matchJson)
        {
            this.PartitionKey = summonerName;
            this.RowKey = matchId;
            this.ChampionId = championId;
            this.MatchCreationTime = creationTime;
            this.Match = matchJson;
        }

        public MatchEntity()
        {
        }
    }
}
