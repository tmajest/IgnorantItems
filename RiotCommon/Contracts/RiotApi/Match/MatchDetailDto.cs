using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.Match
{
    [JsonObject]
    public class MatchDetailDto
    {
        [JsonProperty]
        public int MapId { get; set; }

        [JsonProperty]
        public long MatchCreation { get; set; }

        [JsonProperty]
        public long MatchDuration { get; set; }

        [JsonProperty]
        public long MatchId { get; set; }

        [JsonProperty]
        public string MatchMode { get; set; }

        [JsonProperty]
        public string MatchType { get; set; }

        [JsonProperty]
        public string MatchVersion { get; set; }

        [JsonProperty]
        public List<ParticipantIdentityDto> ParticipantIdentities { get; set; }

        [JsonProperty]
        public List<ParticipantDto> Participants { get; set; }

        [JsonProperty]
        public string PlatformId { get; set; }

        [JsonProperty]
        public string QueueType { get; set; }

        [JsonProperty]
        public string Region { get; set; }

        [JsonProperty]
        public string Season { get; set; }

        [JsonProperty]
        public List<TeamDto> Teams { get; set; }

        [JsonProperty]
        public TimelineDto TimeLine { get; set; }
    }
}
