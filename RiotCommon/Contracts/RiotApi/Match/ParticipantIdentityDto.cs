using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.RiotApi.Match
{
    [JsonObject]
    public class ParticipantIdentityDto
    {
        [JsonProperty]
        public int ParticipantId { get; set; }

        [JsonProperty]
        public PlayerDto Player { get; set; }
    }
}
