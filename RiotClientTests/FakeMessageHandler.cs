using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RiotClientTests
{
    public class FakeMessageHandler : DelegatingHandler
    {
        public Action<HttpRequestMessage> VerifyRequestFunc { get; set; }

        public HttpResponseMessage MockResponse;

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(this.VerifyRequestFunc != null)
            {
                this.VerifyRequestFunc(request);
            }

            if(this.MockResponse != null)
            {
                return Task.FromResult(this.MockResponse);
            }

            return base.SendAsync(request, cancellationToken); 
        }
    }
}
