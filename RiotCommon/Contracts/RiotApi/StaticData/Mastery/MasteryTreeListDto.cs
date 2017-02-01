using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Mastery
{
    [JsonObject]
    public class MasteryTreeListDto
    {
        [JsonProperty]
        public List<MasteryTreeItemDto> MasteryTreeItems { get; set; }
    }
}
