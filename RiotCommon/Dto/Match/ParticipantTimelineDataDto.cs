using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.Match
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
