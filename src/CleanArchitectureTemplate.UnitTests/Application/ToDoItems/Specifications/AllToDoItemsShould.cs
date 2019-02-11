using CleanArchitectureTemplate.Application.ToDoItems.Specifications;
using FluentAssertions;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Application.ToDoItems.Specifications
{
    public class AllToDoItemsShould
    {
        [Fact]
        public void Construct() =>
            new AllToDoItems()
                .Should().BeOfType<AllToDoItems>();

        [Fact]
        public void HaveCacheKey() =>
            new AllToDoItems().CacheKey
                .Should().Be("AllToDoItems-item-true");
    }
}
