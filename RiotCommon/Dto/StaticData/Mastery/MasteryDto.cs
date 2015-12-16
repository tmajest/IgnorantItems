using Newtonsoft.Json;
using System.Collections.Generic;

namespace CoffeeCat.RiotCommon.Dto.StaticData.Mastery
{
    [JsonObject]
    public class MasteryDto
    {
        [JsonProperty]
        public List<string> Description { get; set; }

        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public ImageDto Image { get; set; }

        [JsonProperty]
        public string MasteryTree { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string PreReq { get; set; }

        [JsonProperty]
        public int Ranks { get; set; }

        [JsonProperty]
        public List<string> SanitizedDescription { get; set; }
    }
}
