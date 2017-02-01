using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Champion
{
    [JsonObject]
    public class ChampionSpellDto
    {
        [JsonProperty]
        public List<ImageDto> AltImages { get; set; }

        [JsonProperty]
        public List<double> Cooldown { get; set; }

        [JsonProperty]
        public string CooldownBurn { get; set; }

        [JsonProperty]
        public List<int> Cost { get; set; }

        [JsonProperty]
        public string CostBurn { get; set; }

        [JsonProperty]
        public string CostType { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public List<object> Effect { get; set; }

        [JsonProperty]
        public List<string> EffectBurn { get; set; }

        [JsonProperty]
        public ImageDto Image { get; set; }

        [JsonProperty]
        public string Key { get; set; }

        [JsonProperty]
        public LevelTipDto Leveltip { get; set; }

        [JsonProperty]
        public int Maxrank { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public object Range { get; set; }

        [JsonProperty]
        public string RangeBurn { get; set; }

        [JsonProperty]
        public string Resource { get; set; }

        [JsonProperty]
        public string SanitizedDescription { get; set; }

        [JsonProperty]
        public string SanitizedTooltip { get; set; }

        [JsonProperty]
        public string Tooltip { get; set; }

        [JsonProperty]
        public List<SpellVarsDto> Vars { get; set; }
    }
}
