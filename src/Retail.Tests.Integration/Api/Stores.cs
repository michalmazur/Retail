using Newtonsoft.Json;
using Retail.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Retail.Tests.Integration.Api
{
    [Collection("Default")]
    public class Stores
    {
        private readonly TestHttpClient Client;
        public Stores(TestHttpClient client)
        {
            Client = client;
        }

        [Fact]
        public async Task CanRetrieveStores()
        {
            var response = await Client.Authenticated.GetAsync("/stores");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var responseBody = await response.Content.ReadAsStringAsync();
            var store = JsonConvert
                .DeserializeObject<IEnumerable<StoreViewModel>>(responseBody)
                .Single(s => s.Id == 1);
            Assert.Equal(1, store.Id);
            Assert.Equal("TestStore", store.Label);
        }

        [Fact]
        public async Task CanAddStore()
        {
            var requestBody = new StringContent(
                JsonConvert.SerializeObject(new StoreViewModel { Label = "MyStore" }),
                System.Text.Encoding.UTF8, 
                "application/json"
            );
            var response = await Client.Authenticated.PostAsync("/stores", requestBody);
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);

            var responseBody = await response.Content.ReadAsStringAsync();
            var store = JsonConvert.DeserializeObject<StoreViewModel>(responseBody);
            Assert.Equal("MyStore", store.Label);
            Assert.True(store.Id > 1);
        }
    }
}
