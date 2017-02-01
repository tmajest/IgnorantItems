using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.SummonerSpells
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
