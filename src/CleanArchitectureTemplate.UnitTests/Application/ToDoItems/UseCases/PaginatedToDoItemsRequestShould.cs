using CleanArchitectureTemplate.Application.ToDoItems.Specifications;
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using FluentAssertions;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Application.ToDoItems.UseCases
{
    public class PaginatedToDoItemsRequestShould
    {
        [Fact]
        public void ConstructWithParameters()
        {
            var request = new PaginatedToDoItemsRequest(new AllToDoItems(), 1, 10);
            request.Specification.Should().BeOfType<AllToDoItems>();
            request.PageNumber.Should().Be(1);
            request.PageSize.Should().Be(10);
        }

        [Fact]
        public void SetPageNumberTo1When0() =>
            new PaginatedToDoItemsRequest(new AllToDoItems(), 0, 10)
                .PageNumber.Should().Be(1);
    }
}
