using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Dto.Summoner
{
    [JsonObject]
    public class SummonerDto
    {
        [JsonProperty]
        public long Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public int ProfileIconId { get; set; }

        [JsonProperty]
        public long RevisionDate { get; set; }

        [JsonProperty]
        public long SummonerLevel { get; set; }
    }
}
