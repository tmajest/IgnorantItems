using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Dto.Summoner
{
    [JsonObject]
    public class MasteryDto
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public int Rank { get; set; }
    }
}
