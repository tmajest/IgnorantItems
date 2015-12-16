using CoffeeCat.RiotClient.Endpoints;
using CoffeeCat.RiotCommon.Utils;
using System.Net;

namespace CoffeeCat.RiotClient.Endpoints.Summoner
{
    internal class SummonerByIdEndpoint : RiotEndpoint
    {
        private string summonerIds;

        public override string ApiBase => "api/lol/{0}/v{1}/summoner/{2}";

        public SummonerByIdEndpoint(string region, string version, string apiKey, string summonerIds)
          : base(region, version, apiKey)
        {
            Validation.ValidateNotNullOrWhitespace(summonerIds, nameof(summonerIds));
            this.summonerIds = WebUtility.UrlEncode(summonerIds);
        }

        public override string Format()
        {
            return string.Format(this.ApiBase, this.Region, this.Version, this.summonerIds);
        }
    }
}
