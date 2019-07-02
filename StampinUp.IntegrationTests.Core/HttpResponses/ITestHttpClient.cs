using System;
using System.Net.Http;
using System.Threading.Tasks;
using StampinUp.Core.Testing.Web.Contracts;

namespace StampinUp.Core.IntegrationTests.HttpResponses
{
    public interface ITestHttpClient : IDisposable
    {
        Task<TestHttpResponse> DELETE(string uri, string culture = "en-us", string authorizationScheme = "", string authorizationParam = "");
        Task<TestHttpResponse> GET(string uri);
        Task<TestHttpResponse> POST(string uri, string content, string culture = "en-us", string contentType = "application/json", string authorizationScheme = "", string authorizationParam = "");
        Task<TestHttpResponse> PUT(string uri, string content, string culture = "en-us", string contentType = "application/json", string authorizationScheme = "", string authorizationParam = "");
        void UsingTestServiceClient(Action<HttpClient> httpAction);
    }
}
