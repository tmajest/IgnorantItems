using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Item
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
