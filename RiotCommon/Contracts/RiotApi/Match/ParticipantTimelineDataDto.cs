using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.Match
{
    [JsonObject]
    public class ParticipantTimelineDataDto
    {
        [JsonProperty]
        public double TenToTwenty { get; set; }

        [JsonProperty]
        public double ThirtyToEnd { get; set; }

        [JsonProperty]
        public double TwentyToThirty { get; set; }

        [JsonProperty]
        public double ZeroToTen { get; set; }
    }
}
