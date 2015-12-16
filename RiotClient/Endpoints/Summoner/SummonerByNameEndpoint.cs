using CoffeeCat.RiotClient.Endpoints;
using CoffeeCat.RiotCommon.Utils;
using System.Net;

namespace CoffeeCat.RiotClient.Endpoints.Summoner
{
    internal class SummonerByNameEndpoint : RiotEndpoint
    {
        private string summonerNames;

        public override string ApiBase => "api/lol/{0}/v{1}/summoner/by-name/{2}";

        public SummonerByNameEndpoint(string region, string version, string apiKey, string summonerNames)
          : base(region, version, apiKey)
        {
            Validation.ValidateNotNullOrWhitespace(summonerNames, nameof(summonerNames));
            this.summonerNames = WebUtility.UrlEncode(summonerNames);
        }

        public override string Format()
        {
            return string.Format(this.ApiBase, this.Region, this.Version, this.summonerNames);
        }
    }
}
