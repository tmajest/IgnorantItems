using CoffeeCat.RiotCommon.Utils;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using CoffeeCat.RiotCommon.Contracts.RiotApi.Match;

namespace CoffeeCat.RiotClient.Clients
{
    public class MatchDetailClient : BaseClient
    {
        public string Version { get; private set; }

        public MatchDetailClient(string region, string version, string apiKey) 
            : base(region, apiKey)
        {
            Validation.ValidateNotNullOrWhitespace(version, nameof(version));
            this.Version = version;
        }

        internal MatchDetailClient(string region, string version, string apiKey, Uri baseUri, HttpMessageHandler messageHandler) 
            : base(region, apiKey, baseUri, messageHandler)
        {
            Validation.ValidateNotNullOrWhitespace(version, nameof(version));
            this.Version = version;
        }

        public Task<MatchDetailDto> GetMatchDetails(string matchId)
        {
            Validation.ValidateNotNullOrWhitespace(matchId, nameof(matchId));

            var uri = this.EndpointFactory.GetMatchDetailUri(this.Version, matchId);
            return this.DownloadRiotData<MatchDetailDto>(uri);
        }
    }
}
