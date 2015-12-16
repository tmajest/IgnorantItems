using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.StaticData.Champion
{
    [JsonObject]
    public class InfoDto
    {
        [JsonProperty]
        public int Attack { get; set; }

        [JsonProperty]
        public int Defense { get; set; }

        [JsonProperty]
        public int Difficulty { get; set; }

        [JsonProperty]
        public int Magic { get; set; }
    }
}
