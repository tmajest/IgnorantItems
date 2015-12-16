using Newtonsoft.Json;
using System.Collections.Generic;

namespace CoffeeCat.RiotCommon.Dto.StaticData.Mastery
{
    [JsonObject]
    public class MasteryTreeListDto
    {
        [JsonProperty]
        public List<MasteryTreeItemDto> MasteryTreeItems { get; set; }
    }
}
