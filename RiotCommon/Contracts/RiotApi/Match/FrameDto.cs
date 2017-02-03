using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.Match
{
    [JsonObject]
    public class FrameDto
    {
        [JsonProperty]
        public List<EventDto> Events { get; set; }

        [JsonProperty]
        public Dictionary<string, ParticipantFrameDto> ParticipantFrames { get; set; }

        [JsonProperty]
        public long Timestamp { get; set; }
    }
}
