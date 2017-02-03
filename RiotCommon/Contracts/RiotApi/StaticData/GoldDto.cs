using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData
{
    [JsonObject]
    public class GoldDto
    {
        [JsonProperty]
        public int Base { get; set; }

        [JsonProperty]
        public bool Purchasable { get; set; }

        [JsonProperty]
        public int Sell { get; set; }

        [JsonProperty]
        public int Total { get; set; }
    }
}
