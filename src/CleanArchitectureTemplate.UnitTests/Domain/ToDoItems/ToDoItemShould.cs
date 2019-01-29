using CleanArchitectureTemplate.Domain.ToDoItems;
using FluentAssertions;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Domain.ToDoItems
{
    public class ToDoItemShould
    {
        [Fact]
        public void Construct() =>
            new ToDoItem().Should().BeOfType<ToDoItem>();
    }
}
