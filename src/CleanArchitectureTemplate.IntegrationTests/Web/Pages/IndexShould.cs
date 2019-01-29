using System.Net;
using System.Threading.Tasks;
using CleanArchitectureTemplate.IntegrationTests.Helpers;
using FluentAssertions;
using Xunit;

namespace CleanArchitectureTemplate.IntegrationTests.Web.Pages
{
    [Collection(Constants.WEB_TEST_FIXTURE_COLLECTION)]
    public class IndexShould
    {
        private readonly WebTestFixture _fixture;

        public IndexShould(WebTestFixture fixture) =>
            _fixture = fixture;

        [Fact]
        public async Task ReturnOk()
        {
            var response = await _fixture.HttpClient.GetAsync("/").ConfigureAwait(false);
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }



    }
}
