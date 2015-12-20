using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotClient.Endpoints.StaticData
{
    internal class SummonerSpellsEndpoint : RiotEndpoint
    {
        private static string SpellDataKey = "spellData";
        private static string SpellDataValue = "image,key";

        public override string ApiBase => "api/lol/static-data/{0}/v{1}/summoner-spell";

        public SummonerSpellsEndpoint(string region, string version, string apiKey)
          : base(region, version, apiKey)
        {
            this.QueryParameterDict[SpellDataKey] = SpellDataValue;
        }

        public override string Format()
        {
            return string.Format(this.ApiBase, this.Region, this.Version);
        }
    }
}
