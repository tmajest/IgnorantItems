using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Champion
{
    [JsonObject]
    public class InfoDto
    {
        [JsonProperty]
        public int Attack { get; set; }

        [JsonProperty]
        public int Defense { get; set; }

        [JsonProperty]
        public int Difficulty { get; set; }

        [JsonProperty]
        public int Magic { get; set; }
    }
}
