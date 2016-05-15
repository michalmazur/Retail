using Microsoft.AspNet.TestHost;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;

namespace Retail.Tests.Integration
{
    public class TestHttpClient
    {
        public HttpClient Unauthenticated { get; private set; }
        public HttpClient Authenticated { get; private set; }

        public TestHttpClient()
        {
            var testServer = new TestServer(TestServer.CreateBuilder().UseEnvironment("integration").UseStartup<Retail.Startup>());
            Unauthenticated = testServer.CreateClient();
            Authenticated = testServer.CreateClient();

            // Perform authentication
            var content = new StringContent(
                JsonConvert.SerializeObject(new { username = "user", password = "password" }),
                System.Text.Encoding.UTF8,
                "application/json"
            );
            var response = Authenticated.PostAsync("/session", content);
            response.Wait();
            var setCookieHeaders = response.Result.Headers.GetValues("Set-Cookie").ToList();
            SetCookieHeaderValue cookie = SetCookieHeaderValue.ParseList(setCookieHeaders).First();
            Authenticated.DefaultRequestHeaders.Add("Cookie", cookie.Name + "=" + cookie.Value);
        }
    }

}