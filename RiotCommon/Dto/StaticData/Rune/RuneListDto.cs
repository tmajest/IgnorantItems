using Newtonsoft.Json;
using System.Collections.Generic;

namespace CoffeeCat.RiotCommon.Dto.StaticData.Rune
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
