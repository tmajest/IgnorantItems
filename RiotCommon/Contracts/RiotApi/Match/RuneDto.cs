using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.Match
{
    [JsonObject]
    public class RuneDto
    {
        [JsonProperty]
        public long Rank { get; set; }

        [JsonProperty]
        public long RuneId { get; set; }
    }
}
