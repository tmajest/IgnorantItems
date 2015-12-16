using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.StaticData.Item
{
    [JsonObject]
    public class GroupDto
    {
        [JsonProperty]
        public string MaxGroupOwnable { get; set; }

        [JsonProperty]
        public string Key { get; set; }
    }
}
