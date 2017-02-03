using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Item
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
