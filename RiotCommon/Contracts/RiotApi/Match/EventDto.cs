using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.Match
{
    [JsonObject]
    public class EventDto
    {
        [JsonProperty]
        public string AscendedType { get; set; }

        [JsonProperty]
        public List<int> AssistingParticipantIds { get; set; }

        [JsonProperty]
        public string BuildingType { get; set; }

        [JsonProperty]
        public int CreatorId { get; set; }

        [JsonProperty]
        public string EventType { get; set; }

        [JsonProperty]
        public int ItemAfter { get; set; }

        [JsonProperty]
        public int ItemBefore { get; set; }

        [JsonProperty]
        public int ItemId { get; set; }

        [JsonProperty]
        public int KillerId { get; set; }

        [JsonProperty]
        public string LaneType { get; set; }

        [JsonProperty]
        public string LevelUpType { get; set; }

        [JsonProperty]
        public string MonsterType { get; set; }

        [JsonProperty]
        public int ParticipantId { get; set; }

        [JsonProperty]
        public string PointCaptured { get; set; }

        [JsonProperty]
        public PositionDto Position { get; set; }

        [JsonProperty]
        public int SkillSlot { get; set; }

        [JsonProperty]
        public int TeamId { get; set; }

        [JsonProperty]
        public long Timestamp { get; set; }

        [JsonProperty]
        public string TowerType { get; set; }

        [JsonProperty]
        public int VictimId { get; set; }

        [JsonProperty]
        public string WardType { get; set; }
    }
}
