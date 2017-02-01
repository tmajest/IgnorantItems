using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Champion
{
    [JsonObject]
    public class StatsDto
    {
        [JsonProperty]
        public double Armor { get; set; }

        [JsonProperty]
        public double ArmorPerLevel { get; set; }

        [JsonProperty]
        public double AttackDamage { get; set; }

        [JsonProperty]
        public double AttackDamagePerLevel { get; set; }

        [JsonProperty]
        public double AttackRange { get; set; }

        [JsonProperty]
        public double AttackSpeedOffset { get; set; }

        [JsonProperty]
        public double AttackSpeedPerLevel { get; set; }

        [JsonProperty]
        public double Crit { get; set; }

        [JsonProperty]
        public double CritPerLevel { get; set; }

        [JsonProperty]
        public double Hp { get; set; }

        [JsonProperty]
        public double HpPerLevel { get; set; }

        [JsonProperty]
        public double HpRegen { get; set; }

        [JsonProperty]
        public double HpRegenPerLevel { get; set; }

        [JsonProperty]
        public double Movespeed { get; set; }

        [JsonProperty]
        public double Mp { get; set; }

        [JsonProperty]
        public double MpPerLevel { get; set; }

        [JsonProperty]
        public double MpRegen { get; set; }

        [JsonProperty]
        public double MpRegenPerLevel { get; set; }

        [JsonProperty]
        public double SpellBlock { get; set; }

        [JsonProperty]
        public double SpellBlockPerLevel { get; set; }
    }
}
