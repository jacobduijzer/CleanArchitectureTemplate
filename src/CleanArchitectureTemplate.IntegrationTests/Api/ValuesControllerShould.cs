using System.Net;
using System.Threading.Tasks;
using CleanArchitectureTemplate.IntegrationTests.Helpers;
using FluentAssertions;
using Xunit;

namespace CleanArchitectureTemplate.IntegrationTests.Api
{
    [Collection(Constants.API_TEST_FIXTURE_COLLECTION)]
    public class ValuesControllerShould : IClassFixture<ApiTestFixture>
    {
        private readonly ApiTestFixture _fixture;

        public ValuesControllerShould(ApiTestFixture fixture) =>
            _fixture = fixture;

        [Fact]
        public async Task ReturnOk()
        {
            var result = await _fixture.HttpClient.GetAsync("/api/values").ConfigureAwait(false);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
