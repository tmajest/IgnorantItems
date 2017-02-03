using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Item
{
    [JsonObject]
    public class ItemDto
    {
        [JsonProperty]
        public string Colloq { get; set; }

        [JsonProperty]
        public bool ConsumeOnFull { get; set; }

        [JsonProperty]
        public bool Consumed { get; set; }

        [JsonProperty]
        public int Depth { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public Dictionary<string, string> Effect { get; set; }

        [JsonProperty]
        public List<string> From { get; set; }

        [JsonProperty]
        public GoldDto Gold { get; set; }

        [JsonProperty]
        public string Group { get; set; }

        [JsonProperty]
        public bool HideFromAll { get; set; }

        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public ImageDto Image { get; set; }

        [JsonProperty]
        public bool InStore { get; set; }

        [JsonProperty]
        public List<string> Into { get; set; }

        [JsonProperty]
        public Dictionary<string, bool> Maps { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Plaintext { get; set; }

        [JsonProperty]
        public string RequiredChampion { get; set; }

        [JsonProperty]
        public MetaDataDto Rune { get; set; }

        [JsonProperty]
        public string SanitizedDescription { get; set; }

        [JsonProperty]
        public int SpecialRecipe { get; set; }

        [JsonProperty]
        public int Stacks { get; set; }

        [JsonProperty]
        public BasicDataStatsDto Stats { get; set; }

        [JsonProperty]
        public List<string> Tags { get; set; }
    }
}
