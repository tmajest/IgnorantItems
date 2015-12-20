using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.StaticData.SummonerSpells
{
    [JsonObject]
    public class SummonerSpellListDto
    {
        [JsonProperty]
        public Dictionary<string, SummonerSpellDto> Data { get; set; }

        [JsonProperty]
        public string Type { get; set; }

        [JsonProperty]
        public string Version { get; set; }
    }
}
