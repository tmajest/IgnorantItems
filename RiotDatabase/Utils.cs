using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.UploaderV2;

namespace CoffeeCat.RiotDatabase
{
    public class Utils
    {
        private const string MatchVersionName = "Match";
        private const string MatchListVersionName = "MatchList";
        private const string StaticDataVersionName = "StaticData";
        private const string SummonerVersionName = "Summoner";

        public static ApiVersion GetApiVersion(RiotContext context)
        {
            return new ApiVersion
            {
                MatchVersion = context.ApiVersions.FirstOrDefault(v => v.Name.Equals(MatchVersionName))?.Version,
                MatchListVersion = context.ApiVersions.FirstOrDefault(v => v.Name.Equals(MatchListVersionName))?.Version,
                StaticDataVersion = context.ApiVersions.FirstOrDefault(v => v.Name.Equals(StaticDataVersionName))?.Version,
                SummonerVersion = context.ApiVersions.FirstOrDefault(v => v.Name.Equals(SummonerVersionName))?.Version
            };
        }
    }
}
