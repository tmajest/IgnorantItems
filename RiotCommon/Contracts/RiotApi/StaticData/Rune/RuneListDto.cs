using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Rune
{
    [JsonObject]
    public class RuneListDto
    {
        [JsonProperty]
        public Dictionary<string, RuneDto> Data { get; set; }

        [JsonProperty]
        public string Type { get; set; }

        [JsonProperty]
        public string Version { get; set; }
    }
}
