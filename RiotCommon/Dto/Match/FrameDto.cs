using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.Match
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
