using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Champion
{
    [JsonObject]
    public class SpellVarsDto
    {
        [JsonProperty]
        public List<double> Coeff { get; set; }

        [JsonProperty]
        public string Dyn { get; set; }

        [JsonProperty]
        public string Key { get; set; }

        [JsonProperty]
        public string Link { get; set; }

        [JsonProperty]
        public string RanksWith { get; set; }
    }
}
