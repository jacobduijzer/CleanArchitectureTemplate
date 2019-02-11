using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using FluentAssertions;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Application.ToDoItems.UseCases
{
    public class PaginatedToDoItemsResponseShould
    {
        [Fact]
        public void Construct() =>
            new PaginatedToDoItemsResponse(false)
                .Should().BeOfType<PaginatedToDoItemsResponse>();

        [Fact]
        public void ConstructWithIsSuccesfull() =>
            new PaginatedToDoItemsResponse(true).IsSuccessful
                .Should().BeTrue();
 
    }
}
