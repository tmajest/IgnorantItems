using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Dto.Summoner
{
    [JsonObject]
    public class RuneSlotDto
    {
        [JsonProperty]
        public int RuneId { get; set; }

        [JsonProperty]
        public int RuneSlotId { get; set; }
    }
}
