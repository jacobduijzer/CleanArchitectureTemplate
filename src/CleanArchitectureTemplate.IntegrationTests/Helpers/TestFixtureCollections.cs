using Xunit;

namespace CleanArchitectureTemplate.IntegrationTests.Helpers
{
    [CollectionDefinition(Constants.API_TEST_FIXTURE_COLLECTION)]
    public class ApiTestFixtureCollection : ICollectionFixture<ApiTestFixture>
    {
    }

    [CollectionDefinition(Constants.WEB_TEST_FIXTURE_COLLECTION)]
    public class WebTestFixtureCollection : ICollectionFixture<WebTestFixture>
    {
    }
}
