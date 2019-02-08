using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Domain.ToDoItems;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Application.ToDoItems.UseCases
{
    public class ToDoItemsResponseShould
    {
        [Fact]
        public void Construct() =>
            new ToDoItemsResponse(new List<ToDoItem>())
                .Should().BeOfType<ToDoItemsResponse>();

        [Fact]
        public void SetIsSuccessfulWhenDataAvailable() =>
            new ToDoItemsResponse(new List<ToDoItem>()).IsSuccessful
                .Should().BeTrue();

        [Fact]
        public void SetSuccessAndMessage()
        {
            var response = new ToDoItemsResponse(false, "An error occurred");
            response.IsSuccessful.Should().BeFalse();
            response.Message.Should().Be("An error occurred");
        }
    }
}
