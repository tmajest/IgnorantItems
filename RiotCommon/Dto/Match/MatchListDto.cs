using Newtonsoft.Json;
using System.Collections.Generic;

namespace CoffeeCat.RiotCommon.Dto.Match
{
    [JsonObject]
    public class MatchListDto
    {
        [JsonProperty]
        public int StartIndex { get; set; }

        [JsonProperty]
        public int EndIndex { get; set; }

        [JsonProperty]
        public int TotalGames { get; set; }

        [JsonProperty]
        public List<MatchReferenceDto> Matches { get; set; }
    }
}
