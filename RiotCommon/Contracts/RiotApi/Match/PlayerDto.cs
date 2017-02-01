using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.Match
{
    [JsonObject]
    public class PlayerDto
    {
        [JsonProperty]
        public string MatchHistoryUri { get; set; }

        [JsonProperty]
        public int ProfileIcon { get; set; }

        [JsonProperty]
        public long SummonerId { get; set; }

        [JsonProperty]
        public string SummonerName { get; set; }
    }
}
