using Newtonsoft.Json;
using System.Collections.Generic;

namespace CoffeeCat.RiotCommon.Dto.Summoner
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
