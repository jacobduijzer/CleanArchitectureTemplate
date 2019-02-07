using CleanArchitectureTemplate.IntegrationTests.Helpers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureTemplate.IntegrationTests.Api.Controllers
{
    [Collection(Constants.API_TEST_FIXTURE_COLLECTION)]
    public class ToDoControllerShould
    {
        private readonly ApiTestFixture fixture;

        public ToDoControllerShould(ApiTestFixture fixture) =>
            this.fixture = fixture;

        [Fact]
        public async Task ReturnOk()
        {
            var result = await fixture.HttpClient.GetAsync("/api/todo").ConfigureAwait(false);
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ReturnItems()
        {
            var result = await fixture.Api.GetAllToDoItems().ConfigureAwait(false);
            result.Should().NotBeNullOrEmpty().And.HaveCount(6);
        }
    }
}
