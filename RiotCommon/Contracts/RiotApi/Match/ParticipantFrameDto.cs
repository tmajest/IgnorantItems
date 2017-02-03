using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.Match
{
    [JsonObject]
    public class ParticipantFrameDto
    {
        [JsonProperty]
        public int CurrentGold { get; set; }

        [JsonProperty]
        public int DominionScore { get; set; }

        [JsonProperty]
        public int JungleMinionsKilled { get; set; }

        [JsonProperty]
        public int Level { get; set; }

        [JsonProperty]
        public int MinionsKilled { get; set; }

        [JsonProperty]
        public int ParticipantId { get; set; }

        [JsonProperty]
        public PositionDto position { get; set; }

        [JsonProperty]
        public int TeamScore { get; set; }

        [JsonProperty]
        public int TotalGold { get; set; }

        [JsonProperty]
        public int Xp { get; set; }
    }
}
