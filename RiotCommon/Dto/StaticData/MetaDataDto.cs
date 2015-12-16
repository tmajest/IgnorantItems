using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.StaticData
{
    [JsonObject]
    public class MetaDataDto
    {
        [JsonProperty]
        public bool IsRune { get; set; }

        [JsonProperty]
        public string Tier { get; set; }

        [JsonProperty]
        public string Type { get; set; }
    }
}
