using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<HttpResponseMessage> GetMatches()
        {
            var matches = await this.matchProvider.GetMatches();

            if (matches == null || matches.Count == 0)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, matches);
        }

        [HttpGet]
        [Route("{proName}/{matchId}")]
#if (!DEBUG)
        [CacheOutput(ClientTimeSpan=int.MaxValue, ServerTimeSpan=int.MaxValue)]
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