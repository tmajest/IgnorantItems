using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Champion
{
    [JsonObject]
    public class RecommendedDto
    {
        public List<BlockDto> Blocks { get; set; }

        [JsonProperty]
        public string Champion { get; set; }

        [JsonProperty]
        public string Map { get; set; }

        [JsonProperty]
        public string Mode { get; set; }

        [JsonProperty]
        public bool Priority { get; set; }

        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty]
        public string Type { get; set; }
    }
}
