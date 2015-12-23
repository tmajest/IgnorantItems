using CoffeeCat.RiotCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace RiotFrontend.Controllers.WebApi
{
    [RoutePrefix("api/static")]
    public class StaticDataController : ApiController
    {
        private IStaticData staticData;

        public StaticDataController(IStaticData staticData)
        {
            this.staticData = staticData;
        }

        [HttpGet]
        [Route("masteries")]
#if (!DEBUG)
        [CacheOutput(ClientTimeSpan=int.86000, ServerTimeSpan=86000)]
#endif
        public HttpResponseMessage GetMasteries()
        {
            var masteries = this.staticData.MasteryList.Data;
            return Request.CreateResponse(HttpStatusCode.OK, masteries);
        }

        [HttpGet]
        [Route("summonerSpells")]
#if (!DEBUG)
        [CacheOutput(ClientTimeSpan=int.MaxValue, ServerTimeSpan=int.MaxValue)]
#endif
        public HttpResponseMessage GetSummonerSpells()
        {
            var summonerSpells = this.staticData.SummonerSpellList.Data;
            return Request.CreateResponse(HttpStatusCode.OK, summonerSpells);
        }
    }
}