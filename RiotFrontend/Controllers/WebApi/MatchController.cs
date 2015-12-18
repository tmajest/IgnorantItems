using System.Web.Http;
using CoffeeCat.RiotCommon.Utils;
using RiotFrontend.Providers;
using System.Net;
using System.Net.Http;

namespace RiotFrontend.Controllers.WebApi
{
    [RoutePrefix("api/matches")]
    public class MatchController : ApiController
    {
        private IMatchProvider matchProvider;

        public MatchController(IMatchProvider matchProvider)
        {
            this.matchProvider = matchProvider;
        }

        [HttpGet]
        [Route("")]
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
    }
}
