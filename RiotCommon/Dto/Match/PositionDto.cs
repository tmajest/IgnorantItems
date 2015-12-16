using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.Match
{
    [JsonObject]
    public class PositionDto
    {
        [JsonProperty]
        public int X { get; set; }

        [JsonProperty]
        public int Y { get; set; }
    }
}
