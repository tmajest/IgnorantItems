using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.Match
{
    [JsonObject]
    public class MasteryDto
    {
        [JsonProperty]
        public long MasteryId { get; set; }

        [JsonProperty]
        public long Rank { get; set; }
    }
}
