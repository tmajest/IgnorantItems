using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CoffeeCat.RiotCommon.Utils;
using CoffeeCat.RiotFrontend.Providers;
using WebApi.OutputCache.V2;

namespace CoffeeCat.RiotFrontend.Controllers.WebApi
{
    [RoutePrefix("api/matches")]
    public class MatchController : ApiController
    {
        private readonly IMatchProvider matchProvider;

        public MatchController(IMatchProvider matchProvider)
        {
            this.matchProvider = matchProvider;
        }

        [HttpGet]
        [Route("")]
#if (!DEBUG)
        [CacheOutput(ClientTimeSpan=1800, ServerTimeSpan=1800)]
#endif
        public async Task<HttpResponseMessage> GetMatches(int skip = 0, int count = 15)
        {
            var matchList = await this.matchProvider.GetMatches(skip, count);

            if (matchList?.Matches == null || matchList?.Matches?.Count == 0)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, matchList);
        }

        [HttpGet]
        [Route("{proName}/{matchId}")]
#if (!DEBUG)
        [CacheOutput(ClientTimeSpan=1800, ServerTimeSpan=1800)]
#endif
        public async Task<HttpResponseMessage> GetMatch(string proName, long matchId)
        {
            Validation.ValidateNotNullOrWhitespace(proName, nameof(proName));

            var decodedProName = HttpUtility.UrlDecode(proName);
            var match = await this.matchProvider.GetMatch(decodedProName, matchId);

            return match == null 
                ? new HttpResponseMessage(HttpStatusCode.NotFound) 
                : Request.CreateResponse(match);
        }
    }
}