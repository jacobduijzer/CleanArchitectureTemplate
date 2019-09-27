using CleanArchitectureTemplate.Application.ToDoItems.Events;
using FluentAssertions;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Application.ToDoItems.Events
{
    public class ToDoItemAddedEventHandlerShould
    {
        [Fact]
        public void Construct() =>
            new ToDoItemAddedEventHandler()
                .Should().BeOfType<ToDoItemAddedEventHandler>();
    }
}
