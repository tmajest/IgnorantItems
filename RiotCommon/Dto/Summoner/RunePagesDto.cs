using Newtonsoft.Json;
using System.Collections.Generic;

namespace CoffeeCat.RiotCommon.Dto.Summoner
{
    [JsonObject]
    public class RunePagesDto
    {
        [JsonProperty]
        public List<RunePageDto> Pages { get; set; }

        [JsonProperty]
        public long SummonerId { get; set; }
    }
}
