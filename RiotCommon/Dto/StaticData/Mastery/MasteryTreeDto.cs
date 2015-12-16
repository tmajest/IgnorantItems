using Newtonsoft.Json;
using System.Collections.Generic;

namespace CoffeeCat.RiotCommon.Dto.StaticData.Mastery
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
