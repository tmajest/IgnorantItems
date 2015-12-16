using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.StaticData.Champion
{
    [JsonObject]
    public class LevelTipDto
    {
        [JsonProperty]
        public List<string> Effect { get; set; }

        [JsonProperty]
        public List<string> Label { get; set; }
    }
}
