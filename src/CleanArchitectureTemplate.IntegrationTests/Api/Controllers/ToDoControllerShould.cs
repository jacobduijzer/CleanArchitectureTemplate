using CleanArchitectureTemplate.IntegrationTests.Helpers;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureTemplate.IntegrationTests.Api.Controllers
{
    [Collection(Constants.API_TEST_FIXTURE_COLLECTION)]
    public class ToDoControllerShould
    {
        private readonly ApiTestFixture _fixture;

        public ToDoControllerShould(ApiTestFixture fixture) =>
            _fixture = fixture;

        [Fact(Skip = "Skipped due to AppVeyor / netcore 3 issue")]
        public async Task ReturnOk()
        {
            var result = await _fixture.HttpClient.GetAsync("/api/todo").ConfigureAwait(false);
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(Skip = "Skipped due to AppVeyor / netcore 3 issue")]
        public async Task ReturnItems()
        {
            var result = await _fixture.Api.GetAllToDoItems().ConfigureAwait(false);
            result.Should().NotBeNullOrEmpty().And.HaveCount(6);
        }
    }
}
