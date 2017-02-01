using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Contracts.UploaderV2
{
    public class ApiVersion
    {
        public string MatchVersion { get; set; }

        public string MatchListVersion { get; set; }

        public string StaticDataVersion { get; set; }

        public string SummonerVersion { get; set; }
    }
}
