using CleanArchitectureTemplate.Domain.ToDoItems;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Domain.ToDoItems
{
    public class ToDoItemShould
    {
        [Fact]
        public void Construct() =>
            new ToDoItem().Should().BeOfType<ToDoItem>();

        [Fact]
        public void ConstructWithValues()
        {
            var todoItem = new ToDoItem
            {
                Description = "Test",
                DueDate = DateTime.Now,
                IsDone = true
            };

            todoItem.Should().NotBeNull().And.BeOfType<ToDoItem>();
            todoItem.Description.Should().Be("Test");
            todoItem.DueDate.Should().BeCloseTo(DateTime.Now, 5000); // lazy solution :)
            todoItem.IsDone.Should().BeTrue();
        }
    }
}
