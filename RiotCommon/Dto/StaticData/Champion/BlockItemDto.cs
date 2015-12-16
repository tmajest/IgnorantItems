using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.StaticData.Champion
{
    [JsonObject]
    public class BlockItemDto
    {
        [JsonProperty]
        public int Count { get; set; }

        [JsonProperty]
        public int Id { get; set; }
    }
}
