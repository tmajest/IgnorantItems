using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Champion
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
