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
    public class Products
    {
        private readonly TestHttpClient Client;
        public Products(TestHttpClient client)
        {
            Client = client;
        }

        [Fact]
        public async Task CanRetrieveProduct()
        {
            var response = await Client.Authenticated.GetAsync("/products/1");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var responseBody = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductViewModel>(responseBody);
            Assert.Equal(1, product.Id);
            Assert.Equal("Pizza", product.Label);
        }

        [Fact]
        public async Task CanRetrieveProducts()
        {
            var response = await Client.Authenticated.GetAsync("/products");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var responseBody = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<ProductViewModel>>(responseBody);
            var firstProduct = products.Single(s => s.Id == 1);
            Assert.Contains(products, (s => s.Id == 1 && s.Label == "Pizza"));
        }

        [Fact]
        public async Task<int> CanAddProduct()
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(new ProductViewModelBase
                {
                    Label = "Hamburger",
                    UnitId = 1,
                    Amount = 100
                }), 
                System.Text.Encoding.UTF8, 
                "application/json");
            var response = await Client.Authenticated.PostAsync("/products", content);
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
            
            var responseBody = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductViewModel>(responseBody);
            Assert.Equal("Hamburger", product.Label);
            Assert.Equal(1, product.UnitId);
            Assert.Equal(100, product.Amount);
            Assert.True(product.Id > 1);

            return product.Id;
        }

        [Fact]
        public async Task CanUpdateProduct()
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(new ProductViewModelBase
                {
                    Label = "Pizza",
                    UnitId = 1,
                    Amount = 7,
                    Comments = "My comment",
                    Barcode = "13579",
                }),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = await Client.Authenticated.PutAsync("/products/1", content);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var responseBody = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductViewModel>(responseBody);
            Assert.Equal("Pizza", product.Label);
            Assert.Equal(1, product.UnitId);
            Assert.Equal(7, product.Amount);
            Assert.Equal("My comment", product.Comments);
            Assert.Equal("13579", product.Barcode);
            Assert.Equal(1, product.Id);
        }

        [Fact]
        public async Task CanDeleteProduct()
        {
            int productId = await CanAddProduct();
            var response = await Client.Authenticated.DeleteAsync("/products/" + productId);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
