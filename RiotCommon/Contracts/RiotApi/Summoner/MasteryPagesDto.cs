using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.Summoner
{
    [JsonObject]
    public class MasteryPagesDto
    {
        [JsonProperty]
        public List<MasteryPageDto> Pages { get; set; }

        [JsonProperty]
        public long SummonerId { get; set; }
    }
}
