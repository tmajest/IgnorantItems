using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.StaticData
{
    [JsonObject]
    public class GoldDto
    {
        [JsonProperty]
        public int Base { get; set; }

        [JsonProperty]
        public bool Purchasable { get; set; }

        [JsonProperty]
        public int Sell { get; set; }

        [JsonProperty]
        public int Total { get; set; }
    }
}
