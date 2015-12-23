using CoffeeCat.RiotCommon.Utils;
using RiotFrontend.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace RiotFrontend.Controllers.WebApi
{
    [RoutePrefix("api/champions")]
    public class ChampionController : ApiController
    {
        private IMatchProvider matchProvider;
        private IStaticData staticData;

        public ChampionController(IMatchProvider matchProvider, IStaticData staticData)
        {
            Validation.ValidateNotNull(matchProvider, nameof(matchProvider));
            Validation.ValidateNotNull(staticData, nameof(staticData));

            this.matchProvider = matchProvider;
            this.staticData = staticData;
        }

        [HttpGet]
        [Route("")]
#if (!DEBUG)
        [CacheOutput(ClientTimeSpan=86000, ServerTimeSpan=int.86000)]
#endif
        public HttpResponseMessage GetChampions()
        {
            var champions = this.staticData.ChampionList.Data.Values.OrderBy(c => c.Name);
            return Request.CreateResponse(HttpStatusCode.OK, champions);
        }

        [HttpGet]
        [Route("{championId}")]
#if (!DEBUG)
        [CacheOutput(ClientTimeSpan=3600, ServerTimeSpan=3600)]
#endif
        public HttpResponseMessage GetMatchesByChampion(string championId)
        {
            Validation.ValidateNotNullOrWhitespace(championId, nameof(championId));

            var matches = this.matchProvider.GetMatches(championId);
            return Request.CreateResponse(HttpStatusCode.OK, matches);
        }
    }
}
