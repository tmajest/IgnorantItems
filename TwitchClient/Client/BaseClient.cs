using CoffeeCat.RiotCommon.Utils;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TwitchClient.Client
{
    public class BaseClient : IDisposable
    {
        private HttpClient httpClient;
        bool disposed = false;

        public string BaseAddress => "https://api.twitch.tv/kraken";

        public BaseClient(string clientId)
        {
            this.httpClient = new HttpClient()
            {
                BaseAddress = new Uri(this.BaseAddress),
            };
            this.httpClient.DefaultRequestHeaders.Add("Client-Id", clientId);
        }

        internal BaseClient(string clientId, Uri baseAddress, HttpMessageHandler messageHandler)
        {
            this.httpClient = new HttpClient(messageHandler)
            {
                BaseAddress = baseAddress,
            };
            this.httpClient.DefaultRequestHeaders.Add("Client-Id", clientId);
        }

        protected async Task<T> DownloadTwitchData<T>(Uri uri) where T : class
        {
            Validation.ValidateNotNull(uri, nameof(uri));

            var response = await httpClient.GetAsync(uri);

            // TODO: replace this with retry logic
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonUtils.Deserialize<T>(responseBody);
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
    }
}
