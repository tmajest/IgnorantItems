using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.Match
{
    [JsonObject]
    public class TeamDto
    {
        [JsonProperty]
        public List<BannedChampionDto> Bans { get; set; }

        [JsonProperty]
        public int BaronKills { get; set; }

        [JsonProperty]
        public long DominionVictoryScore { get; set; }

        [JsonProperty]
        public bool FirstBaron { get; set; }
        
        [JsonProperty]
        public bool FirstDragon { get; set; }

        [JsonProperty]
        public bool FirstInhibitor { get; set; }

        [JsonProperty]
        public bool FirstRiftHerald { get; set; }

        [JsonProperty]
        public bool FirstTower { get; set; }

        [JsonProperty]
        public int InhibitorKills { get; set; }

        [JsonProperty]
        public int RiftHeraldKills { get; set; }

        [JsonProperty]
        public int TeamId { get; set; }

        [JsonProperty]
        public int VilemawKills { get; set; }

        [JsonProperty]
        public bool Winner { get; set; }
    }
}
