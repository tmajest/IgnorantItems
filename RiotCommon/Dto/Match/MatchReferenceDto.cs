using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Dto.Match
{
    [JsonObject]
    public class MatchReferenceDto
    {
        [JsonProperty]
        public long Champion { get; set; }

        [JsonProperty]
        public string Lane { get; set; }

        [JsonProperty]
        public long MatchId { get; set; }

        [JsonProperty]
        public string PlatformId { get; set; }

        [JsonProperty]
        public string Queue { get; set; }

        [JsonProperty]
        public string Region { get; set; }

        [JsonProperty]
        public string Role { get; set; }

        [JsonProperty]
        public string Season { get; set; }

        [JsonProperty]
        public long Timestamp { get; set; }
    }
}
