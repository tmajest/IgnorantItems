using CoffeeCat.RiotCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotClient.Endpoints.Match
{
    internal class MatchDetailEndpoint : RiotEndpoint
    {
        private static string IncludeTimelineKey = "includeTimeline";

        public override string ApiBase => "api/lol/{0}/v{1}/match/{2}";
        private string matchId;

        public MatchDetailEndpoint(string region, string version, string apiKey, string matchId)
          : base(region, version, apiKey)
        {
            Validation.ValidateNotNullOrWhitespace(matchId, nameof(matchId));
            this.matchId = matchId;

            this.QueryParameterDict[IncludeTimelineKey] = "true";
        }

        public override string Format()
        {
            return string.Format(this.ApiBase, this.Region, this.Version, this.matchId);
        }
    }
}
