using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.Match
{
    [JsonObject]
    public class RuneDto
    {
        [JsonProperty]
        public long Rank { get; set; }

        [JsonProperty]
        public long RuneId { get; set; }
    }
}
