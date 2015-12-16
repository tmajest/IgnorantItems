using CoffeeCat.RiotClient.Clients;
using CoffeeCat.RiotCommon.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotClientTests
{
    [TestClass]
    [DeploymentItem("Responses", "Responses")]
    public class ClientTests
    {
        private static string Region = "na";
        private string apiKey;

        private static readonly Uri BaseUri = new Uri("http://localhost");

        [TestInitialize]
        public void Setup()
        {
            apiKey = Guid.NewGuid().ToString(); 
        }

        [TestMethod]
        public async Task TestSummonerClient_ByName()
        {
            var version = "1.4";
            var summonerName = "doublelift";

            var expectedUriString = $"{Region}/v{version}/summoner/by-name/{summonerName}";

            var fakeMessageHandler = this.CreateFakeMessageHandler("SummonerByName.json", expectedUriString);

            using (var summonerClient = new SummonerClient(Region, version, this.apiKey, ClientTests.BaseUri, fakeMessageHandler))
            {
                var summoner = await summonerClient.GetSummonerByName(summonerName);
                Assert.IsNotNull(summoner);
            }
        }

        [TestMethod]
        public async Task TestSummonerClient_ByMultipleNames()
        {
            var version = "1.4";
            var summonerName = "doublelift";
            var summonerName2 = "c9sneaky";
            var encodedNames = WebUtility.UrlEncode(string.Join(",", summonerName, summonerName2));

            var expectedUriString = $"{Region}/v{version}/summoner/by-name/{encodedNames}";
            var fakeMessageHandler = this.CreateFakeMessageHandler("MultiSummonerByName.json",  expectedUriString);

            using (var summonerClient = new SummonerClient(Region, version, this.apiKey, ClientTests.BaseUri, fakeMessageHandler))
            {
                var summonerDict = await summonerClient.GetSummonerByName(new List<string> { summonerName, summonerName2 });
                Assert.IsNotNull(summonerDict);
                Assert.IsTrue(summonerDict.ContainsKey(summonerName));
                Assert.IsTrue(summonerDict.ContainsKey(summonerName2));
            }
        }

        [TestMethod]
        public async Task TestSummonerClient_ById()
        {
            var version = "1.4";
            var summonerId = "20132258";
            var expectedUriString = $"{Region}/v{version}/summoner/{summonerId}";

            var fakeMessageHandler = this.CreateFakeMessageHandler("SummonerById.json", expectedUriString);

            using (var summonerClient = new SummonerClient(Region, version, this.apiKey, ClientTests.BaseUri, fakeMessageHandler))
            {
                var summoner = await summonerClient.GetSummonerById(summonerId);
                Assert.IsNotNull(summoner);
            }
        }

        [TestMethod]
        public async Task TestSummonerClient_ByMultipleIds()
        {
            var version = "1.4";
            var summonerId = "20132258";
            var summonerId2 = "51405";
            var encodedIds = WebUtility.UrlEncode(string.Join(",", summonerId, summonerId2));
            var expectedUriString = $"{Region}/v{version}/summoner/{encodedIds}";

            var fakeMessageHandler = this.CreateFakeMessageHandler("MultiSummonerById.json", expectedUriString);

            using (var summonerClient = new SummonerClient(Region, version, this.apiKey, ClientTests.BaseUri, fakeMessageHandler))
            {
                var summonerDict = await summonerClient.GetSummonerById(new List<string> { summonerId, summonerId2 });
                Assert.IsNotNull(summonerDict);
                Assert.IsTrue(summonerDict.ContainsKey(summonerId));
                Assert.IsTrue(summonerDict.ContainsKey(summonerId2));
            }
        }

        [TestMethod]
        public async Task TestSummonerClient_SummonerMasteries()
        {
            var version = "1.4";
            var summonerId = "20132258";
            var expectedUriString = $"{Region}/v{version}/summoner/{summonerId}/masteries";

            var fakeMessageHandler = this.CreateFakeMessageHandler("SummonerMasteriesById.json", expectedUriString);

            using (var summonerClient = new SummonerClient(Region, version, this.apiKey, ClientTests.BaseUri, fakeMessageHandler))
            {
                var masteries = await summonerClient.GetSummonerMasteries(summonerId);
                Assert.IsNotNull(masteries);
            }
        }

        [TestMethod]
        public async Task TestSummonerClient_MultipleSummonerMasteries()
        {
            var version = "1.4";
            var summonerId = "20132258";
            var summonerId2 = "51405";
            var encodedIds = WebUtility.UrlEncode(string.Join(",", summonerId, summonerId2));
            var expectedUriString = $"{Region}/v{version}/summoner/{encodedIds}/masteries";

            var fakeMessageHandler = this.CreateFakeMessageHandler("MultiSummonerMasteriesById.json", expectedUriString);

            using (var summonerClient = new SummonerClient(Region, version, this.apiKey, ClientTests.BaseUri, fakeMessageHandler))
            {
                var masteriesDict = await summonerClient.GetSummonerMasteries(new List<string> { summonerId, summonerId2 });
                Assert.IsNotNull(masteriesDict);
                Assert.IsTrue(masteriesDict.ContainsKey(summonerId));
                Assert.IsTrue(masteriesDict.ContainsKey(summonerId2));
            }
        }

        [TestMethod]
        public async Task TestSummonerClient_SummonerRunes()
        {
            var version = "1.4";
            var summonerId = "20132258";
            var expectedUriString = $"{Region}/v{version}/summoner/{summonerId}/runes";

            var fakeMessageHandler = this.CreateFakeMessageHandler("SummonerRunesById.json", expectedUriString);

            using (var summonerClient = new SummonerClient(Region, version, this.apiKey, ClientTests.BaseUri, fakeMessageHandler))
            {
                var masteries = await summonerClient.GetSummonerRunes(summonerId);
                Assert.IsNotNull(masteries);
            }
        }

        [TestMethod]
        public async Task TestSummonerClient_MultipleSummonerRunes()
        {
            var version = "1.4";
            var summonerId = "20132258";
            var summonerId2 = "51405";
            var encodedIds = WebUtility.UrlEncode(string.Join(",", summonerId, summonerId2));
            var expectedUriString = $"{Region}/v{version}/summoner/{encodedIds}/runes";

            var fakeMessageHandler = this.CreateFakeMessageHandler("MultiSummonerRunesById.json", expectedUriString);

            using (var summonerClient = new SummonerClient(Region, version, this.apiKey, ClientTests.BaseUri, fakeMessageHandler))
            {
                var masteriesDict = await summonerClient.GetSummonerRunes(new List<string> { summonerId, summonerId2 });
                Assert.IsNotNull(masteriesDict);
                Assert.IsTrue(masteriesDict.ContainsKey(summonerId));
                Assert.IsTrue(masteriesDict.ContainsKey(summonerId2));
            }
        }

        [TestMethod]
        public async Task TestStaticDataClient()
        {
            var version = "1.2";
            var fakeMessageHander = new FakeMessageHandler();
            using (var staticDataClient = new StaticDataClient(Region, version, this.apiKey, ClientTests.BaseUri, fakeMessageHander))
            {
                var masteriesUriString = $"static-data/{ClientTests.Region}/v{version}/mastery";
                fakeMessageHander.MockResponse = this.CreateFakeResponse("Masteries.json");
                var masteriesAdditionalParams = new Dictionary<string, string>()
                {
                    ["masteryListData"] = "all"
                };
                fakeMessageHander.VerifyRequestFunc = this.CreateVerifyResponseAction(masteriesUriString, masteriesAdditionalParams);
                var masteries = await staticDataClient.GetMasteries();
                Assert.IsNotNull(masteries);

                var runesUriString = $"static-data/{ClientTests.Region}/v{version}/rune";
                fakeMessageHander.MockResponse = this.CreateFakeResponse("Runes.json");
                fakeMessageHander.VerifyRequestFunc = this.CreateVerifyResponseAction(runesUriString);
                var runes = await staticDataClient.GetRunes();
                Assert.IsNotNull(runes);

                var championsUriString = $"static-data/{ClientTests.Region}/v{version}/champion";
                fakeMessageHander.MockResponse = this.CreateFakeResponse("Champions.json");
                var championsAdditionalParams = new Dictionary<string, string>()
                {
                    ["champData"] = "all",
                    ["dataById"] = "true"
                };
                fakeMessageHander.VerifyRequestFunc = this.CreateVerifyResponseAction(championsUriString, championsAdditionalParams);
                var champions = await staticDataClient.GetChampions();
                Assert.IsNotNull(champions);

                var itemsUriString = $"static-data/{ClientTests.Region}/v{version}/item";
                fakeMessageHander.MockResponse = this.CreateFakeResponse("Items.json");
                var itemsAdditionalParams = new Dictionary<string, string>()
                {
                    ["itemListData"] = "all"
                };
                fakeMessageHander.VerifyRequestFunc = this.CreateVerifyResponseAction(itemsUriString, itemsAdditionalParams);
                var items = await staticDataClient.GetItems();
                Assert.IsNotNull(items);
            }
        }

        [TestMethod]
        public async Task TestMatchListClient()
        {
            var version = "2.2";
            var summonerId = "20132258";

            // Only get matches in the last week
            var beginTime = DateTime.UtcNow.Subtract(TimeSpan.FromDays(7));
            var endTime = DateTime.UtcNow;

            var expectedUriString = $"{Region}/v{version}/matchlist/by-summoner/{summonerId}";

            var fakeMessageHandler = new FakeMessageHandler();
            using (var client = new MatchListClient(Region, version, this.apiKey, ClientTests.BaseUri, fakeMessageHandler))
            {
                fakeMessageHandler.MockResponse = this.CreateFakeResponse("MatchListClient.json");
                var matchList = await client.GetMatchList(summonerId);
                Assert.IsNotNull(matchList);

                fakeMessageHandler.MockResponse = this.CreateFakeResponse("MatchListClientDateTime.json");
                var additionalParams = new Dictionary<string, string>()
                {
                    ["beginTime"] = DateTimeUtils.ToUnixTimestamp(beginTime),
                    ["endTime"] = DateTimeUtils.ToUnixTimestamp(endTime)
                };
                fakeMessageHandler.VerifyRequestFunc = this.CreateVerifyResponseAction(expectedUriString, additionalParams);
                matchList = await client.GetMatchList(summonerId, beginTime, endTime);
                Assert.IsNotNull(matchList);
            }
        }

        [TestMethod]
        public async Task TestMatchDetailClient()
        {
            var version = "2.2";
            var matchId = "2029231395";

            var expectedUriString = $"{Region}/v{version}/match/{matchId}";

            var additionalParams = new Dictionary<string, string>()
            {
                ["includeTimeline"] = "true",
            };

            var fakeMessageHandler = this.CreateFakeMessageHandler("Match.json", expectedUriString, additionalParams);

            using (var client = new MatchDetailClient(Region, version, this.apiKey, ClientTests.BaseUri, fakeMessageHandler))
            {
                var matchDetail = await client.GetMatchDetails(matchId);
                Assert.IsNotNull(matchDetail);
            }
        }

        private Action<HttpRequestMessage> CreateVerifyResponseAction(string expectedUriString, Dictionary<string, string> additionalParams = null)
        {
            var fullExpectedUriString = $"{ClientTests.BaseUri.OriginalString}/api/lol/{expectedUriString}?api_key={this.apiKey}";
            if(additionalParams != null)
            {
                var joined = additionalParams.Select(kv => string.Format("{0}={1}", kv.Key, kv.Value));
                fullExpectedUriString = $"{fullExpectedUriString}&{string.Join("&", joined)}";
            }
            return requestMessage =>
            {
                Assert.AreEqual(fullExpectedUriString, requestMessage.RequestUri.AbsoluteUri);
            };
        }

        private HttpResponseMessage CreateFakeResponse(string filePath, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            string jsonContent = File.ReadAllText(@"Responses\" + filePath);
            return new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(jsonContent),
            };
        }

        private FakeMessageHandler CreateFakeMessageHandler(string filePath, string expectedUriString, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new FakeMessageHandler()
            {
                MockResponse = this.CreateFakeResponse(filePath, statusCode),
                VerifyRequestFunc = CreateVerifyResponseAction(expectedUriString),
            };
        }

        private FakeMessageHandler CreateFakeMessageHandler(string filePath, string expectedUriString, Dictionary<string, string> additionalParams, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new FakeMessageHandler()
            {
                MockResponse = this.CreateFakeResponse(filePath, statusCode),
                VerifyRequestFunc = CreateVerifyResponseAction(expectedUriString, additionalParams),
            };
        }
    }
}
