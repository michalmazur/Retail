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
    public class Prices
    {
        private readonly TestHttpClient Client;
        public Prices(TestHttpClient client)
        {
            Client = client;
        }

        [Fact]
        public async Task CanGetPrice()
        {
            var response = await Client.Authenticated.GetAsync("/products/1/prices");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var responseBody = await response.Content.ReadAsStringAsync();
            var price = JsonConvert.DeserializeObject<IEnumerable<PriceViewModel>>(responseBody).Single(p => p.Id == 1);
            Assert.Equal(1, price.Id);
            Assert.Equal(1, price.ProductId);
            Assert.False(price.Bogo);
            Assert.False(price.Sale);
            Assert.Equal(1, price.StoreId);
            Assert.Equal(5.00m, price.Price);
        }

        [Fact]
        public async Task<int> CanAddPrice()
        {
            var content = new StringContent(JsonConvert.SerializeObject(
                new PriceViewModel
                {
                    Bogo = false,
                    Sale = true,
                    StoreId = 1,
                    ProductId = 1,
                    Price = 10
                }), 
                System.Text.Encoding.UTF8, 
                "application/json"
            );
            var response = await Client.Authenticated.PostAsync("/products/1/prices", content);
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);

            var responseBody = await response.Content.ReadAsStringAsync();
            var price = JsonConvert.DeserializeObject<PriceViewModel>(responseBody);
            Assert.True(price.Id > 1);
            Assert.Equal(10.00m, price.Price);
            return price.Id;
        }

        [Fact]
        public async Task CanDeletePrice()
        {
            int priceId = await CanAddPrice();
            var response = await Client.Authenticated.DeleteAsync("/products/1/prices/" + priceId);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
