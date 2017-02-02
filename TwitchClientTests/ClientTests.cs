using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Newtonsoft.Json;
using TwitchClient.Dto;
using RiotClientTests;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using TwitchClient.Client;

namespace TwitchClientTests
{
    [TestClass]
    [DeploymentItem("Samples", "Samples")]
    public class ClientTests
    {
        private static readonly Uri BaseUri = new Uri("http://localhost");
        private const string ClientId = "clientId";

        [TestMethod]
        public void DeserializeTest()
        {
            var json = File.ReadAllText(@"Samples\VideoListSample.json");

            var videoList = JsonConvert.DeserializeObject<VideoListDto>(json);

            Assert.IsNotNull(videoList);
        }

        [TestMethod]
        public async Task TestGetChannelVideos()
        {
            var channelName = "tsm_dyrus";
            var limit = 10;
            var offset = 20;
            var broadcasts = true;
            var hls = false;
            var expectedUriString = $"channels/{channelName}/videos";

            var additionalParams = new Dictionary<string, string>()
            {
                ["limit"] = limit.ToString(),
                ["offset"] = offset.ToString(),
                ["broadcasts"] = broadcasts.ToString(),
                ["hls"] = hls.ToString()
            };
            var fakeMessageHandler = this.CreateFakeMessageHandler("VideoListSample.json", expectedUriString, additionalParams);

            using (var client = new ChannelVideosClient(ClientTests.ClientId, ClientTests.BaseUri, fakeMessageHandler))
            {
                var videoList = await client.GetChannelVideoList(channelName, limit, offset, broadcasts, hls);

                Assert.AreEqual(82, videoList.Total);
            } 
        }

        private Action<HttpRequestMessage> CreateVerifyResponseAction(string expectedUriString, Dictionary<string, string> additionalParams = null)
        {
            var fullExpectedUriString = $"{ClientTests.BaseUri.OriginalString}/{expectedUriString}";
            if (additionalParams != null)
            {
                var joined = additionalParams.Select(kv => string.Format("{0}={1}", kv.Key, kv.Value));
                fullExpectedUriString = $"{fullExpectedUriString}?{string.Join("&", joined)}";
            }
            return requestMessage =>
            {
                Assert.AreEqual(fullExpectedUriString, requestMessage.RequestUri.AbsoluteUri);
            };
        }

        private HttpResponseMessage CreateFakeResponse(string filePath, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            string jsonContent = File.ReadAllText(@"Samples\" + filePath);
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
