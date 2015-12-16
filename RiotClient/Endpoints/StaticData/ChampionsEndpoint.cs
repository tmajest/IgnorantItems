using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotClient.Endpoints.StaticData
{
    internal class ChampionsEndpoint : RiotEndpoint
    {
        private static string ChampDataKey = "champData";
        private static string DataByIdKey = "dataById";

        public override string ApiBase => "api/lol/static-data/{0}/v{1}/champion";

        public ChampionsEndpoint(string region, string version, string apiKey)
          : base(region, version, apiKey)
        {
            this.QueryParameterDict[ChampDataKey] = "all";
            this.QueryParameterDict[DataByIdKey] = "true";
        }

        public override string Format()
        {
            return string.Format(this.ApiBase, this.Region, this.Version);
        }
    }
}
