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
        private readonly WebTestFixture fixture;

        public ToDoShould(WebTestFixture fixture) =>
            this.fixture = fixture;

        [Fact]
        public async Task ReturnOk()
        {
            var response = await fixture.HttpClient.GetAsync("/todo").ConfigureAwait(false);
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
