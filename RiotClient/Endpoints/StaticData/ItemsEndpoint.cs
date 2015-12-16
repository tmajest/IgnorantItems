using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotClient.Endpoints.StaticData
{
    internal class ItemsEndpoint : RiotEndpoint
    {
        private static string ItemListDataKey = "itemListData";

        public override string ApiBase => "api/lol/static-data/{0}/v{1}/item";

        public ItemsEndpoint(string region, string version, string apiKey)
          : base(region, version, apiKey)
        {
            this.QueryParameterDict[ItemListDataKey] = "all";
        }

        public override string Format()
        {
            return string.Format(this.ApiBase, this.Region, this.Version);
        }
    }
}
