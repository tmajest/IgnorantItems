using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.Match
{
    [JsonObject]
    public class ParticipantStatsDto
    {
        [JsonProperty]
        public long Assists { get; set; }

        [JsonProperty]
        public long ChampLevel { get; set; }

        [JsonProperty]
        public long CombatPlayerScore { get; set; }

        [JsonProperty]
        public long Deaths { get; set; }

        [JsonProperty]
        public long DoubleKills { get; set; }

        [JsonProperty]
        public bool FirstBloodAssist { get; set; }

        [JsonProperty]
        public bool FirstBloodKill { get; set; }

        [JsonProperty]
        public bool FirstInhibitorAssist { get; set; }

        [JsonProperty]
        public bool FirstInhibitorKill  { get; set; }

        [JsonProperty]
        public bool FirstTowerKill { get; set; }

        [JsonProperty]
        public long GoldEarned { get; set; }

        [JsonProperty]
        public long GoldSpent { get; set; }

        [JsonProperty]
        public long InhibitorKills { get; set; }

        [JsonProperty]
        public long Item0 { get; set; }

        [JsonProperty]
        public long Item1 { get; set; }

        [JsonProperty]
        public long Item2 { get; set; }

        [JsonProperty]
        public long Item3 { get; set; }

        [JsonProperty]
        public long Item4 { get; set; }

        [JsonProperty]
        public long Item5 { get; set; }

        [JsonProperty]
        public long Item6 { get; set; }

        [JsonProperty]
        public long KillingSprees { get; set; }

        [JsonProperty]
        public long Kills { get; set; }

        [JsonProperty]
        public long LargestCriticalStrike { get; set; }

        [JsonProperty]
        public long LargestKillingSpree { get; set; }

        [JsonProperty]
        public long LargestMultiKill { get; set; }

        [JsonProperty]
        public long MagicDamageDelt { get; set; }

        [JsonProperty]
        public long MagicDamageDeltToChampions { get; set; }

        [JsonProperty]
        public long MagicDamageTaken { get; set; }

        [JsonProperty]
        public long MinionsKilled { get; set; }

        [JsonProperty]
        public long NeutralMinionsKilled { get; set; }

        [JsonProperty]
        public long NeutralMinionsKilledEnemyJungle { get; set; }

        [JsonProperty]
        public long NeutralMinionsKilledTeamJungle { get; set; }

        [JsonProperty]
        public long NodeCaptured { get; set; }

        [JsonProperty]
        public long NodeCapturedAssist { get; set; }

        [JsonProperty]
        public long NodeNeutralize { get; set; }

        [JsonProperty]
        public long NodeNeutralizeAssist { get; set; }

        [JsonProperty]
        public long ObjectivePlayerScore { get; set; }

        [JsonProperty]
        public long Pentakills { get; set; }

        [JsonProperty]
        public long PhysicalDamageDelt { get; set; }

        [JsonProperty]
        public long PhysicalDamageDeltToChampions { get; set; }

        [JsonProperty]
        public long PhysicalDamageTaken { get; set; }

        [JsonProperty]
        public long QuadraKills { get; set; }

        [JsonProperty]
        public long SightWardsBoughtInGame { get; set; }

        [JsonProperty]
        public long TeamObjective { get; set; }

        [JsonProperty]
        public long TotalDamageDelt { get; set; }

        [JsonProperty]
        public long TotalDamageDeltToChampions { get; set; }

        [JsonProperty]
        public long TotalDamageTaken { get; set; }

        [JsonProperty]
        public long TotalHeal { get; set; }

        [JsonProperty]
        public long TotalPlayerScore { get; set; }

        [JsonProperty]
        public long TotalPlayerRank { get; set; }

        [JsonProperty]
        public long TotalTimeCrowdControlDelt { get; set; }

        [JsonProperty]
        public long TotalUnitsHealed { get; set; }

        [JsonProperty]
        public long TowerKills { get; set; }

        [JsonProperty]
        public long TripleKills { get; set; }

        [JsonProperty]
        public long TrueDamageDelt { get; set; }

        [JsonProperty]
        public long TrueDamageDeltToChampions { get; set; }

        [JsonProperty]
        public long UnrealKills { get; set; } 

        [JsonProperty]
        public long VisionWardsBoughtInGame { get; set; } 

        [JsonProperty]
        public long WardsKilled { get; set; } 

        [JsonProperty]
        public bool Winner { get; set; } 
    }
}
