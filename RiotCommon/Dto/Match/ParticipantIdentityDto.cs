using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.Match
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
