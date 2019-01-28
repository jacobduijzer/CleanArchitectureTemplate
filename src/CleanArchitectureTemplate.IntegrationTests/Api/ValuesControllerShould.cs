using CleanArchitectureTemplate.IntegrationTests.Helpers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureTemplate.IntegrationTests.Api
{
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
