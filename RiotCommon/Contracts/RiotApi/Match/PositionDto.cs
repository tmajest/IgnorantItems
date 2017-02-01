using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.Match
{
    [JsonObject]
    public class PositionDto
    {
        [JsonProperty]
        public int X { get; set; }

        [JsonProperty]
        public int Y { get; set; }
    }
}
