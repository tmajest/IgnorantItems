using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData
{
    [JsonObject]
    public class MetaDataDto
    {
        [JsonProperty]
        public bool IsRune { get; set; }

        [JsonProperty]
        public string Tier { get; set; }

        [JsonProperty]
        public string Type { get; set; }
    }
}
