using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Mastery
{
    [JsonObject]
    public class MasteryListDto
    {
        [JsonProperty]
        public Dictionary<string, MasteryDto> Data { get; set; }

        [JsonProperty]
        public MasteryTreeDto Tree { get; set; }

        [JsonProperty]
        public string Type { get; set; }

        [JsonProperty]
        public string Version { get; set; }
    }
}
