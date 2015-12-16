using System;
using System.Collections.Generic;
using CoffeeCat.RiotCommon.Dto.Match;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.Uploader
{
    [JsonObject]
    public class MatchInfo
    {
        [JsonProperty]
        public string MatchId { get; set; }

        [JsonProperty]
        public DateTime MatchCreationTime { get; set; }

        [JsonProperty]
        public string SummonerName { get; set; }

        [JsonProperty]
        public string ProName { get; set; }

        [JsonProperty]
        public string SummonerId { get; set; }

        [JsonProperty]
        public string ChampionId { get; set; }

        [JsonProperty]
        public string Region { get; set; }
        
        [JsonProperty]
        public List<MasteryDto> Masteries { get; set; }

        [JsonProperty]
        public List<RuneDto> Runes { get; set; }

        [JsonProperty]
        public bool Won { get; set; }

        [JsonProperty]
        public long MatchDuration { get; set; }

        [JsonProperty]
        public long Kills { get; set; }

        [JsonProperty]
        public long Deaths { get; set; }

        [JsonProperty]
        public long Assists { get; set; }

        [JsonProperty]
        public List<BannedChampionDto> TeamBannedChampions { get; set; }

        [JsonProperty]
        public List<BannedChampionDto> EnemyTeamBannedChampions { get; set; }

        [JsonProperty]
        public List<string> ItemsBought { get; set; }
    }
}
