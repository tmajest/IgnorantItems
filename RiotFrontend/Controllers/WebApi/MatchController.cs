using System.Web.Http;
using CoffeeCat.RiotCommon.Utils;
using RiotFrontend.Providers;

namespace RiotFrontend.Controllers.WebApi
{
    [Route("matches")]
    public class MatchController : ApiController
    {
        private IMatchProvider matchProvider;

        public MatchController(IMatchProvider matchProvider)
        {
            this.matchProvider = matchProvider;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetMatches()
        {
            var matches = this.matchProvider.GetMatches();
            if (matches == null || matches.Count == 0)
            {
                return this.NotFound();
            }

            return this.Ok(matches);
        }

        [HttpGet]
        [Route("{matchId}")]
        public IHttpActionResult GetMatch(string matchId)
        {
            Validation.ValidateNotNullOrWhitespace(matchId, nameof(matchId));
            var match = this.matchProvider.GetMatch(matchId);
            if (match == null)
            {
                return this.NotFound();
            }

            return this.Ok(match);
        }
    }
}
