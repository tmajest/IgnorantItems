using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.StaticData
{
    [JsonObject]
    public class ImageDto
    {
        [JsonProperty]
        public string Full { get; set; }

        [JsonProperty]
        public string Group { get; set; }

        [JsonProperty]
        public string Sprite { get; set; }

        [JsonProperty]
        public int H { get; set; }

        [JsonProperty]
        public int W { get; set; }

        [JsonProperty]
        public int X { get; set; }

        [JsonProperty]
        public int Y { get; set; }
    }
}
