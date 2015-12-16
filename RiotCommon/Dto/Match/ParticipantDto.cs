using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.Match
{
    [JsonObject]
    public class ParticipantDto
    {
        [JsonProperty]
        public int ChampionId { get; set; }

        [JsonProperty]
        public string HighestAchievedSeasonTier { get; set; }

        [JsonProperty]
        public List<MasteryDto> Masteries { get; set; }

        [JsonProperty]
        public int ParticipantId { get; set; }

        [JsonProperty]
        public List<RuneDto> Runes { get; set; }

        [JsonProperty]
        public int Spell1Id { get; set; }

        [JsonProperty]
        public int Spell2Id { get; set; }

        [JsonProperty]
        public ParticipantStatsDto Stats { get; set; }

        [JsonProperty]
        public int TeamId { get; set; }

        [JsonProperty]
        public ParticipantTimelineDataDto Timeline { get; set; }
    }
}
