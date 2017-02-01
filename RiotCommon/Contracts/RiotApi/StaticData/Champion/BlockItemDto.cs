using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Champion
{
    [JsonObject]
    public class BlockItemDto
    {
        [JsonProperty]
        public int Count { get; set; }

        [JsonProperty]
        public int Id { get; set; }
    }
}
