using System;
using System.Collections.Generic;
using System.Linq;

namespace TwitchClient.Endpoints
{
    public abstract class TwitchEndpoint
    {
        public abstract string Format();

        protected abstract IDictionary<string, string> CreateQueryParameters();

        public Uri GetUri()
        {
            var apiBaseFormatted = this.Format();

            var queryParameterDict = this.CreateQueryParameters();
            var joined = queryParameterDict.Where(kv => kv.Value != null).Select(kv => string.Format("{0}={1}", kv.Key, kv.Value));
            var queryParameters = string.Join("&", joined);

            var uriString = string.Format("{0}?{1}", apiBaseFormatted, queryParameters);

            return new Uri(uriString, UriKind.Relative);
        }
    }
}
