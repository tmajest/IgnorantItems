﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.UploaderV2
{
    [JsonObject]
    public class RuneInstance
    {
        [JsonProperty]
        public int RuneId { get; set; }

        [JsonProperty]
        public int Rank { get; set; }
    }
}