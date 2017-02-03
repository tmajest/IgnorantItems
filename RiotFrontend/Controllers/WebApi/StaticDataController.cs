using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoffeeCat.RiotCommon.Utils;
using WebApi.OutputCache.V2;

namespace CoffeeCat.RiotFrontend.Controllers.WebApi
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
        [CacheOutput(ClientTimeSpan=3600, ServerTimeSpan=3600)]
#endif
        public HttpResponseMessage GetMasteries()
        {
            var masteries = this.staticData.MasteryList.Data;
            return Request.CreateResponse(HttpStatusCode.OK, masteries);
        }

        [HttpGet]
        [Route("summonerSpells")]
#if (!DEBUG)
        [CacheOutput(ClientTimeSpan=3600, ServerTimeSpan=3600)]
#endif
        public HttpResponseMessage GetSummonerSpells()
        {
            var summonerSpells = this.staticData.SummonerSpellList.Data;
            return Request.CreateResponse(HttpStatusCode.OK, summonerSpells);
        }
    }
}