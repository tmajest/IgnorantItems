using CoffeeCat.RiotClient.Endpoints;
using CoffeeCat.RiotCommon.Utils;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoffeeCat.RiotClient.Clients
{
    public class BaseClient : IDisposable
    {
        private HttpClient httpClient;
        private bool disposed;

        internal EndpointFactory EndpointFactory;

        public string BaseAddress => "api.pvp.net";

        public string Region { get; private set; }

        public string ApiKey { get; private set; }

        public BaseClient(string region, string apiKey)
        {
            Validation.ValidateNotNullOrWhitespace(region, nameof(region));
            Validation.ValidateNotNullOrWhitespace(apiKey, nameof(apiKey));

            this.Region = region;
            this.ApiKey = apiKey;
            this.EndpointFactory = new EndpointFactory(apiKey, region);

            var baseUri = new Uri(string.Format("https://{0}.{1}", region, BaseAddress));
            this.httpClient = new HttpClient()
            {
                BaseAddress = baseUri,
            };
        }

        internal BaseClient(string region, string apiKey, Uri baseUri, HttpMessageHandler messageHandler)
        {
            Validation.ValidateNotNullOrWhitespace(region, nameof(region));
            Validation.ValidateNotNullOrWhitespace(apiKey, nameof(apiKey));
            Validation.ValidateNotNull(baseUri, nameof(baseUri));
            Validation.ValidateNotNull(messageHandler, nameof(messageHandler));

            this.Region = region;
            this.ApiKey = apiKey;
            this.EndpointFactory = new EndpointFactory(apiKey, region);
            this.httpClient = new HttpClient(messageHandler)
            {
                BaseAddress = baseUri,
            };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                this.httpClient.Dispose();
            }

            disposed = true;
        }

        protected async Task<T> DownloadRiotData<T>(Uri uri) where T : class
        {
            Validation.ValidateNotNull(uri, nameof(uri));

            var response = await httpClient.GetAsync(uri);

            // TODO: replace this with retry logic
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonUtils.Deserialize<T>(responseBody);
        }
    }
}
