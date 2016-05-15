using Newtonsoft.Json;
using Retail.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Retail.Tests.Integration.Api
{
    [Collection("Default")]
    public class Units
    {
        private readonly TestHttpClient Client;
        public Units(TestHttpClient client)
        {
            this.Client = client;
        }

        [Fact]
        public async Task CanRetrieveUnits()
        {
            var response = await Client.Authenticated.GetAsync("/units");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var responseBody = await response.Content.ReadAsStringAsync();
            var units = JsonConvert.DeserializeObject<IEnumerable<UnitViewModel>>(responseBody);
            Assert.Contains(units, (u => u.Id == 1 && u.Label == "ct"));
        }
    }
}
