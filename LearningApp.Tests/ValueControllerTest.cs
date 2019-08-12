using System;
using Xunit;
using LearningApp.Controllers;
using System.Threading.Tasks;
using static LearningApp.Controllers.ValuesController;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System.Net;

namespace LearningApp.Tests
{
    public class ValueControllerTest : IClassFixture<TestServerFixture>
    {
        private readonly TestServerFixture _fixture;
        private readonly string psbWithNoOfficeList = "{'PricingSchedule':{	'Skus':[{'SkuId':'AL1040_PG1','SkuPrice':[15.00,10.00,0.00,7.00]}],'EffectiveDate':'08-08-2019'}}";

        public ValueControllerTest(TestServerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ValueControllerHappyPath()
        {
            var response = await _fixture.Client.GetAsync("api/values");

            response.EnsureSuccessStatusCode();

            var responseStrong = await response.Content.ReadAsStringAsync();


        }

        [Fact]
        public async Task ValueControllerPost()
        {
            var pricingschedulebatch = JsonConvert.DeserializeObject<PricingScheduleBatch>(psbWithNoOfficeList);
            var stringContent = new StringContent(JsonConvert.SerializeObject(pricingschedulebatch), Encoding.UTF8, "application/json");
            var response = await _fixture.Client.PostAsync("api/values", stringContent);

            response.StatusCode.Equals(HttpStatusCode.BadRequest);
        }
    }
}
