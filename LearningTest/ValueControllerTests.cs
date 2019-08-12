using LearningTest;
using Xunit;
using System.Threading.Tasks;

namespace LearningTest
{
    public class ValueControllerTests: IClassFixture<TestServerFixture>
    {
        private readonly TestServerFixture _fixture;

        public ValueControllerTests(TestServerFixture fixture)
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
    }
}