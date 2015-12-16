using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.Match
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
