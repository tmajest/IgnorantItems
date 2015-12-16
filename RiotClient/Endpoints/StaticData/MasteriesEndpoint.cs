using CoffeeCat.RiotClient.Endpoints;

namespace CoffeeCat.RiotClient.Endpoints.StaticData
{
    internal class MasteriesEndpoint : RiotEndpoint
    {
        private static string masteryListDataKey = "masteryListData";
        private static string masteryListDataValue = "all";

        public override string ApiBase => "api/lol/static-data/{0}/v{1}/mastery";

        public MasteriesEndpoint(string region, string version, string apiKey)
          : base(region, version, apiKey)
        {
            this.QueryParameterDict[MasteriesEndpoint.masteryListDataKey] = MasteriesEndpoint.masteryListDataValue;
        }

        public override string Format()
        {
            return string.Format(this.ApiBase, this.Region, this.Version);
        }
    }
}
