using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Champion
{
    [JsonObject]
    public class LevelTipDto
    {
        [JsonProperty]
        public List<string> Effect { get; set; }

        [JsonProperty]
        public List<string> Label { get; set; }
    }
}
