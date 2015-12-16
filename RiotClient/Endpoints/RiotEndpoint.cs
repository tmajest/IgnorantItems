using CoffeeCat.RiotCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CoffeeCat.RiotClient.Endpoints
{
    internal abstract class RiotEndpoint
    {
        private static string ApiKeyName = "api_key";

        protected Dictionary<string, string> QueryParameterDict { get; private set; }

        public string Region { get; private set; }
        public string Version { get; private set; }

        public abstract string ApiBase { get; }

        public RiotEndpoint(string region, string version, string apiKey)
        {
            Validation.ValidateNotNullOrWhitespace(region, "region");
            Validation.ValidateNotNullOrWhitespace(version, "version");
            Validation.ValidateNotNullOrWhitespace(apiKey, "apiKey");

            this.Region = region;
            this.Version = version;

            this.QueryParameterDict = new Dictionary<string, string>();
            this.QueryParameterDict[RiotEndpoint.ApiKeyName] = apiKey;
        }

        public abstract string Format();

        public Uri GetUri()
        {
            var apiBaseFormatted = this.Format();
            var queryParameters = this.GetQueryParameterString();
            var uriString = string.Format("{0}?{1}", apiBaseFormatted, queryParameters);

            return new Uri(uriString, UriKind.Relative);
        }

        private string GetQueryParameterString()
        {
            var joined = this.QueryParameterDict.Select(kv => string.Format("{0}={1}", kv.Key, kv.Value));
            return string.Join("&", joined);
        }
    }
}
