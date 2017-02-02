using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CoffeeCat.RiotCommon.Utils;
using CoffeeCat.RiotFrontend.Providers;

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

        public MatchController()
        {
            matchProvider = null;
        }

        [HttpGet]
        [Route("")]
#if (!DEBUG)
        [CacheOutput(ClientTimeSpan=3600, ServerTimeSpan=3600)]
#endif
        public HttpResponseMessage GetMatches()
        {
            var matches = this.matchProvider.GetMatches();

            if (matches == null || matches.Count == 0)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, matches);
        }

        [HttpGet]
        [Route("{matchId}")]
#if (!DEBUG)
        [CacheOutput(ClientTimeSpan=int.MaxValue, ServerTimeSpan=int.MaxValue)]
#endif
        public HttpResponseMessage GetMatch(string matchId)
        {
            Validation.ValidateNotNullOrWhitespace(matchId, nameof(matchId));

            var match = this.matchProvider.GetMatch(matchId);

            if (match == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(match);
        }

        [HttpGet]
        [Route("{summonerName}/{matchId}")]
#if (!DEBUG)
        [CacheOutput(ClientTimeSpan=int.MaxValue, ServerTimeSpan=int.MaxValue)]
#endif
        public HttpResponseMessage GetMatch(string summonerName, string matchId)
        {
            Validation.ValidateNotNullOrWhitespace(matchId, nameof(matchId));

            var decodedSummonerName = HttpUtility.UrlDecode(summonerName);

            var match = this.matchProvider.GetMatch(matchId, decodedSummonerName);

            if (match == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(match);
        }
    }
}