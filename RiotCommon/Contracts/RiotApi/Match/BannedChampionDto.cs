using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.Match
{
    [JsonObject]
    public class BannedChampionDto
    {
        [JsonProperty]
        public int ChampionId { get; set; }

        [JsonProperty]
        public int PickTurn { get; set; }
    }
}
