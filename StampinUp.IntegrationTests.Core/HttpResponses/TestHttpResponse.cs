using System.Net;
using System.Net.Http;

namespace StampinUp.Core.IntegrationTests.HttpResponses
{
    public class TestHttpResponse
    {
        public TestHttpResponse() { }

        public HttpStatusCode StatusCode { get; set; }
        public string RawContent { get; set; }
        public HttpResponseMessage Response { get; set; }
    }
}
