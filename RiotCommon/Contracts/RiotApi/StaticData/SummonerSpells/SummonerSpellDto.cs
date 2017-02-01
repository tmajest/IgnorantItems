using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.SummonerSpells
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
