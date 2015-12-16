using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.Uploader
{
    [JsonObject]
    public class ApiVersion
    {
        [JsonProperty]
        public string StaticDataVersion { get; set; }

        [JsonProperty]
        public string MatchVersion { get; set; }

        [JsonProperty]
        public string MatchListVersion { get; set; }

        [JsonProperty]
        public string SummonerVersion { get; set; }
    }
}
