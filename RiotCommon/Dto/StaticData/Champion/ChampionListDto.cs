using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.StaticData.Champion
{
    [JsonObject]
    public class ChampionListDto
    {
        [JsonProperty]
        public Dictionary<string, ChampionDto> Data { get; set; }

        [JsonProperty]
        public string Format { get; set; }

        [JsonProperty]
        public Dictionary<string, string> Keys { get; set; }

        [JsonProperty]
        public string Type { get; set; }

        [JsonProperty]
        public string Version { get; set; }
    }
}
