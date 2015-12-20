using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.StaticData.SummonerSpells
{
    [JsonObject]
    public class SummonerSpellDto
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public ImageDto Image { get; set; }

        [JsonProperty]
        public string Key { get; set; }
    }
}
