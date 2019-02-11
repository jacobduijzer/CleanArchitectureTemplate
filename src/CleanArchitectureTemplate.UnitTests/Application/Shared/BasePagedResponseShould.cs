using CleanArchitectureTemplate.Application.Shared;
using FluentAssertions;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Application.Shared
{
    public class BasePagedResponseShould
    {
        [Fact]
        public void ConstructWithAllParameters()
        {
            var basePagedResponse = new BasePagedResponse(true, true, 3);
            basePagedResponse.Should().NotBeNull();
            basePagedResponse.IsSuccessful.Should().BeTrue();
            basePagedResponse.HasPreviousPage.Should().BeTrue();
            basePagedResponse.CurrentPageNumber.Should().Be(3);
        }

        [Fact]
        public void ConstructWithSuccess() =>
            new BasePagedResponse(true).IsSuccessful
                .Should().BeTrue();

        [Fact]
        public void ConstructWithSuccessAndMessage()
        {
            var basePagedResponse = new BasePagedResponse(true, "testmessage");
            basePagedResponse.IsSuccessful.Should().BeTrue();
            basePagedResponse.Message.Should().Be("testmessage");
        }
    }
}
