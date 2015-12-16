using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.StaticData.Champion
{
    [JsonObject]
    public class ChampionDto
    {
        [JsonProperty]
        public List<string> Allytips { get; set; }

        [JsonProperty]
        public string Blurb { get; set; }

        [JsonProperty]
        public List<string> Enemytips { get; set; }

        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public ImageDto Image { get; set; }

        [JsonProperty]
        public InfoDto Info { get; set; }

        [JsonProperty]
        public string Key { get; set; }

        [JsonProperty]
        public string Lore { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Partype { get; set; }

        [JsonProperty]
        public PassiveDto Passive { get; set; }

        [JsonProperty]
        public List<RecommendedDto> Recommended { get; set; }

        [JsonProperty]
        public List<SkinDto> Skins { get; set; }

        [JsonProperty]
        public List<ChampionSpellsDto> Spells { get; set; }

        [JsonProperty]
        public StatsDto Stats { get; set; }

        [JsonProperty]
        public List<string> Tags { get; set; }

        [JsonProperty]
        public string Title { get; set; }
    }
}