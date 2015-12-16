using CoffeeCat.RiotClient.Endpoints;
using CoffeeCat.RiotCommon.Utils;
using System;
using System.Net;

namespace CoffeeCat.RiotClient.Endpoints.Match
{
    internal class MatchListEndpoint : RiotEndpoint
    {
        private static string BeginTimeKey = "beginTime";
        private static string EndTimeKey = "endTime";
        private string summonerId;

        public override string ApiBase => "api/lol/{0}/v{1}/matchlist/by-summoner/{2}";

        public MatchListEndpoint(string region, string version, string apiKey, string summonerId)
          : base(region, version, apiKey)
        {
            Validation.ValidateNotNullOrWhitespace(summonerId, nameof(summonerId));
            this.summonerId = WebUtility.UrlEncode(summonerId);
        }

        public MatchListEndpoint(string region, string version, string apiKey, string summonerId, DateTime beginTime, DateTime endTime)
          : base(region, version, apiKey)
        {
            Validation.ValidateNotNullOrWhitespace(summonerId, nameof(summonerId));
            this.summonerId = summonerId;

            this.QueryParameterDict[MatchListEndpoint.BeginTimeKey] = DateTimeUtils.ToUnixTimestamp(beginTime);
            this.QueryParameterDict[MatchListEndpoint.EndTimeKey] = DateTimeUtils.ToUnixTimestamp(endTime);
        }

        public override string Format()
        {
            return string.Format(this.ApiBase, this.Region, this.Version, this.summonerId);
        }
    }
}
