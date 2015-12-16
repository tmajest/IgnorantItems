using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.Match
{
    [JsonObject]
    public class ParticipantTimelineDto
    {
        [JsonProperty]
        public ParticipantTimelineDataDto AncientGolemAssistsPerMinCounts { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto AncientGolemKillsPerMinCounts { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto AssistedLaneDeathsPerMinDeltas { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto AssistedLaneKillsPerMinDeltas { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto BaronAssistsPerMinCounts { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto BaronKillsPerMinCounts { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto CreepsPerMinDeltas { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto CsDiffPerMinDeltas { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto DamageTakenDiffPerMinDeltas { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto DamageTakenPerMinDeltas { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto DragonAssistsPerMinCounts { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto DragonKillsPerMinCounts { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto ElderLizardAssistsPerMinCounts { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto ElderLizardKillsPerMinCounts { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto GoldPerMinDeltas { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto InhibitorAssistsPerMinCounts { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto InhibitorKillsPerMinCounts { get; set; }

        [JsonProperty]
        public string Lane { get; set; }

        [JsonProperty]
        public string Role { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto TowerAssistsPerMinCounts { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto TowerKillsPerMinCounts { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto TowerKillsPerMinDeltas { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto VilemawAssistsPerMinCounts { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto VilemawKillsPerMinCounts { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto WardsPerMinDeltas { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto XpDiffPerMinDeltas { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto XpPerMinDeltas { get; set; }
    }
}
