using CoffeeCat.RiotCommon.Dto.Summoner;
using CoffeeCat.RiotCommon.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.RiotApi.Summoner;

namespace CoffeeCat.RiotClient.Clients
{
    public class SummonerClient : BaseClient
    {
        public string Version { get; private set; }

        public SummonerClient(string region, string version, string apiKey)
          : base(region, apiKey)
        {
            Validation.ValidateNotNull(version, nameof(version));
            this.Version = version;
        }

        internal SummonerClient(string region, string version, string apiKey, Uri baseUri, HttpMessageHandler messageHandler)
          : base(region, apiKey, baseUri, messageHandler)
        {
            Validation.ValidateNotNull(version, nameof(version));
            this.Version = version;
        }

        public async Task<SummonerDto> GetSummonerByName(string summonerName)
        {
            var summonersDict = await this.GetSummonerByName(new List<string> { summonerName });
            var normalizedName = summonerName.ToLowerInvariant();

            if (!summonersDict.ContainsKey(normalizedName))
            {
                throw new InvalidDataException("Summoner was not included in response");
            }

            return summonersDict[normalizedName];
        }

        public Task<Dictionary<string, SummonerDto>> GetSummonerByName(List<string> summonerNames)
        {
            Validation.ValidateNotNullOrEmpty(summonerNames, nameof(summonerNames));
            summonerNames.ForEach((name => Validation.ValidateNotNullOrWhitespace(name, "summonerName")));

            var joinedNames = string.Join(",", (IEnumerable<string>)summonerNames);
            var uri = this.EndpointFactory.GetSummonerByNameUri(this.Version, joinedNames);
            return this.DownloadRiotData<Dictionary<string, SummonerDto>>(uri);
        }

        public async Task<SummonerDto> GetSummonerById(string summonerId)
        {
            var summonersDict = await this.GetSummonerById(new List<string>() { summonerId });

            if (!summonersDict.ContainsKey(summonerId))
            {
                throw new InvalidDataException("Summoner was not included in the response");
            }

            return summonersDict[summonerId];
        }

        public Task<Dictionary<string, SummonerDto>> GetSummonerById(List<string> summonerIds)
        {
            Validation.ValidateNotNullOrEmpty(summonerIds, nameof(summonerIds));
            summonerIds.ForEach(id => Validation.ValidateNotNullOrWhitespace(id, "summonerId"));

            var joinedIds = string.Join(",", summonerIds);
            var uri = this.EndpointFactory.GetSummonerByIdUri(this.Version, joinedIds);
            return this.DownloadRiotData<Dictionary<string, SummonerDto>>(uri);
        }

        public async Task<MasteryPagesDto> GetSummonerMasteries(string summonerId)
        {
            var masteriesDict = await this.GetSummonerMasteries(new List<string>() { summonerId });
            if (!masteriesDict.ContainsKey(summonerId))
            {
                throw new InvalidDataException("Summoner's Masteries were not included in the response.");
            }

            return masteriesDict[summonerId];
        }

        public Task<Dictionary<string, MasteryPagesDto>> GetSummonerMasteries(List<string> summonerIds)
        {
            Validation.ValidateNotNullOrEmpty(summonerIds, nameof(summonerIds));
            summonerIds.ForEach(id => Validation.ValidateNotNullOrWhitespace(id, "summonerId"));

            var idsJoined = string.Join(",", summonerIds);
            var uri = this.EndpointFactory.GetSummonerMasteriesUri(this.Version, idsJoined);
            return this.DownloadRiotData<Dictionary<string, MasteryPagesDto>>(uri);
        }

        public Task<Dictionary<string, RunePagesDto>> GetSummonerRunes(List<string> summonerIds)
        {
            Validation.ValidateNotNullOrEmpty(summonerIds, nameof(summonerIds));
            summonerIds.ForEach(id => Validation.ValidateNotNullOrWhitespace(id, "summonerId"));

            var idsJoined = string.Join(",", summonerIds);
            var uri = this.EndpointFactory.GetSummonerRunesUri(this.Version, idsJoined);
            return this.DownloadRiotData<Dictionary<string, RunePagesDto>>(uri);
        }

        public async Task<RunePagesDto> GetSummonerRunes(string summonerId)
        {
            var runesDict = await this.GetSummonerRunes(new List<string>() { summonerId });

            if (!runesDict.ContainsKey(summonerId))
            {
                throw new InvalidDataException("Summoner's Rune Pages were not included in the response.");
            }

            return runesDict[summonerId];
        }
    }
}
