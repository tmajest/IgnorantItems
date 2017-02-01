using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Champion
{
    [JsonObject]
    public class PassiveDto
    {
        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public ImageDto Image { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string SanitizedDescription { get; set; }
    }
}
