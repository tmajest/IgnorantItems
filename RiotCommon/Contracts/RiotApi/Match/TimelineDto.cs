using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.Match
{
    [JsonObject]
    public class TimelineDto
    {
        [JsonProperty]
        public long FrameInterval { get; set; }

        [JsonProperty]
        public List<FrameDto> Frames { get; set; }
    }
}
