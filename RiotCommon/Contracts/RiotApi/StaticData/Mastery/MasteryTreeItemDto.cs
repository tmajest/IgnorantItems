using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Mastery
{
    [JsonObject]
    public class MasteryTreeItemDto
    {
        [JsonProperty]
        public int MasteryId { get; set; }

        [JsonProperty]
        public string PreReq { get; set; }
    }
}
