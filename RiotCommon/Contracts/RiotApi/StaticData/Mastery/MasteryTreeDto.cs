using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Mastery
{
    [JsonObject]
    public class MasteryTreeDto
    {
        [JsonProperty]
        public List<MasteryTreeListDto> Cunning { get; set; }

        [JsonProperty]
        public List<MasteryTreeListDto> Ferocity { get; set; }

        [JsonProperty]
        public List<MasteryTreeListDto> Resolve { get; set; }
    }
}
