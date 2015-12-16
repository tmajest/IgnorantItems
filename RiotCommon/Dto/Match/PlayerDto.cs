using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.Match
{
    [JsonObject]
    public class PlayerDto
    {
        [JsonProperty]
        public string MatchHistoryUri { get; set; }

        [JsonProperty]
        public int ProfileIcon { get; set; }

        [JsonProperty]
        public long SummonerId { get; set; }

        [JsonProperty]
        public string SummonerName { get; set; }
    }
}
