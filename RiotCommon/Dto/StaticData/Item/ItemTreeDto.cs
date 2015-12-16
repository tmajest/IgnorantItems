using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.StaticData.Item
{
    [JsonObject]
    public class ItemTreeDto
    {
        [JsonProperty]
        public string Header { get; set; }

        [JsonProperty]
        public List<string> Tags { get; set; }
    }
}
