using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.StaticData.Champion
{
    [JsonObject]
    public class BlockDto
    {
        [JsonProperty]
        public List<BlockItemDto> Items { get; set; }

        [JsonProperty]
        public bool RecMath { get; set; }

        [JsonProperty]
        public string Type { get; set; }
    }
}
