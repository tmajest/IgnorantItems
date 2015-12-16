using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.StaticData.Item
{
    [JsonObject]
    public class ItemListDto
    {
        [JsonProperty]
        public BasicDataDto Basic { get; set; }

        [JsonProperty]
        public Dictionary<string, ItemDto> Data { get; set; }

        [JsonProperty]
        public List<GroupDto> Groups { get; set; }

        [JsonProperty]
        public List<ItemTreeDto> Tree { get; set; }

        [JsonProperty]
        public string Type { get; set; }

        [JsonProperty]
        public string Version { get; set; }
    }
}
