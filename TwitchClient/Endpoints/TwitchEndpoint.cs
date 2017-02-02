namespace CoffeeCat.TwitchClient.Endpoints
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class TwitchEndpoint
    {
        public abstract string Format();

        protected abstract IDictionary<string, string> CreateQueryParameters();

        public Uri GetUri()
        {
            var apiBaseFormatted = this.Format();

            var queryParameterDict = this.CreateQueryParameters();
            var joined = queryParameterDict.Where(kv => kv.Value != null).Select(kv => $"{kv.Key}={kv.Value}");
            var queryParameters = string.Join("&", joined);

            var uriString = $"{apiBaseFormatted}?{queryParameters}";

            return new Uri(uriString, UriKind.Relative);
        }
    }
}
