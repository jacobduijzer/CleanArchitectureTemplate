using CleanArchitectureTemplate.IntegrationTests.Helpers;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureTemplate.IntegrationTests.Web.Pages
{
    [Collection(Constants.WEB_TEST_FIXTURE_COLLECTION)]
    public class ToDoShould
    {
        private readonly WebTestFixture _fixture;

        public ToDoShould(WebTestFixture fixture) =>
            _fixture = fixture;

        [Fact]
        public async Task ReturnOk()
        {
            var response = await _fixture.HttpClient.GetAsync("/todo").ConfigureAwait(false);
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
