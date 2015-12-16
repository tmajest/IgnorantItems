using CoffeeCat.RiotClient.Endpoints;

namespace CoffeeCat.RiotClient.Endpoints.StaticData
{
    internal class RunesEndpoint : RiotEndpoint
    {
        private static readonly string RuneListDataKey = "runeListData";

        public override string ApiBase => "api/lol/static-data/{0}/v{1}/rune";

        public RunesEndpoint(string region, string version, string apiKey)
          : base(region, version, apiKey)
        {
            this.QueryParameterDict[RuneListDataKey] = "all";
        }

        public override string Format()
        {
            return string.Format(this.ApiBase, this.Region, this.Version);
        }
    }
}
