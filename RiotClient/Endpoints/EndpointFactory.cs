using CoffeeCat.RiotClient.Endpoints.Match;
using CoffeeCat.RiotClient.Endpoints.StaticData;
using CoffeeCat.RiotClient.Endpoints.Summoner;
using CoffeeCat.RiotCommon.Utils;
using System;

namespace CoffeeCat.RiotClient.Endpoints
{
    internal class EndpointFactory
    {
        public string ApiKey { get; private set; }

        public string Region { get; private set; }

        public EndpointFactory(string apiKey, string region)
        {
            Validation.ValidateNotNullOrWhitespace(region, nameof(region));
            Validation.ValidateNotNullOrWhitespace(apiKey, nameof(apiKey));

            this.Region = region;
            this.ApiKey = apiKey;
        }

        public Uri GetSummonerByNameUri(string version, string summonerNames)
        {
            return new SummonerByNameEndpoint(this.Region, version, this.ApiKey, summonerNames).GetUri();
        }

        public Uri GetSummonerByIdUri(string version, string summonerIds)
        {
            return new SummonerByIdEndpoint(this.Region, version, this.ApiKey, summonerIds).GetUri();
        }

        public Uri GetSummonerMasteriesUri(string version, string summonerIds)
        {
            return new SummonerMasteriesEndpoint(this.Region, version, this.ApiKey, summonerIds).GetUri();
        }

        public Uri GetSummonerRunesUri(string version, string summonerIds)
        {
            return new SummonerRunesEndpoint(this.Region, version, this.ApiKey, summonerIds).GetUri();
        }

        public Uri GetMasteriesUri(string version)
        {
            return new MasteriesEndpoint(this.Region, version, this.ApiKey).GetUri();
        }

        public Uri GetRunesUri(string version)
        {
            return new RunesEndpoint(this.Region, version, this.ApiKey).GetUri();
        }

        public Uri GetChampionsUri(string version)
        {
            return new ChampionsEndpoint(this.Region, version, this.ApiKey).GetUri();
        }

        public Uri GetItemsUri(string version)
        {
            return new ItemsEndpoint(this.Region, version, this.ApiKey).GetUri();
        }

        public Uri GetMatchListUri(string version, string summonerId)
        {
            return new MatchListEndpoint(this.Region, version, this.ApiKey, summonerId).GetUri();
        }

        public Uri GetMatchListUri(string version, string summonerId, DateTime beginTime, DateTime endTime)
        {
            return new MatchListEndpoint(this.Region, version, this.ApiKey, summonerId, beginTime, endTime).GetUri();
        }

        public Uri GetMatchDetailUri(string version, string matchId)
        {
            return new MatchDetailEndpoint(this.Region, version, this.ApiKey, matchId).GetUri();
        }
    }
}
