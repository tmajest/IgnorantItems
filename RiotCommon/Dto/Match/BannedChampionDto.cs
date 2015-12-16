using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.Match
{
    [JsonObject]
    public class BannedChampionDto
    {
        [JsonProperty]
        public int ChampionId { get; set; }

        [JsonProperty]
        public int PickTurn { get; set; }
    }
}
