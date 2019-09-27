using Bogus;
using CleanArchitectureTemplate.Domain.ToDoItems;
using System;
using System.Collections.Generic;

namespace CleanArchitectureTemplate.FakeData.ToDoItems
{
    public static class ToDoItemData
    {
        public static List<ToDoItem> ToDoItems => new List<ToDoItem>
        {
            new ToDoItem { Id = 1, Description = "Do the dishes", DueDate = DateTime.Now.AddDays(-3), IsDone = true },
            new ToDoItem { Id = 2, Description = "Clean the aquarium pump", DueDate = DateTime.Now.AddDays(1), IsDone = true },
            new ToDoItem { Id = 3, Description = "Vacuum the living room", DueDate = DateTime.Now.AddDays(3), IsDone = false }
        };

        public static List<ToDoItem> ToDoItemsForTesting => new List<ToDoItem>
        {
            new ToDoItem { Id = 1, Description = "Do the dishes", DueDate = DateTime.Now.AddDays(-3), IsDone = true },
            new ToDoItem { Id = 2, Description = "Clean the aquarium pump", DueDate = DateTime.Now.AddDays(1), IsDone = true },
            new ToDoItem { Id = 3, Description = "Vacuum the living room", DueDate = DateTime.Now.AddDays(3), IsDone = false },
            new ToDoItem { Id = 4, Description = "Do the dishes", DueDate = DateTime.Now.AddDays(-3), IsDone = true },
            new ToDoItem { Id = 5, Description = "Clean the aquarium pump", DueDate = DateTime.Now.AddDays(1), IsDone = true },
            new ToDoItem { Id = 6, Description = "Vacuum the living room", DueDate = DateTime.Now.AddDays(3), IsDone = false }
        };

        public static List<ToDoItem> GenerateTestData(int numberOfRecords)
        {
            //Set the randomzier seed if you wish to generate repeatable data sets.
            Randomizer.Seed = new Random(8675309);

            var orderIds = 1;
            return new Faker<ToDoItem>()
                .RuleFor(item => item.Id, (faker, item) => orderIds++)
                .RuleFor(item => item.Description, (faker, item) => faker.Lorem.Sentence(4))
                .RuleFor(item => item.IsDone, (faker, item) => faker.Random.Bool())
                .RuleFor(item => item.DueDate, (faker, item) => item.IsDone ? faker.Date.Past() : faker.Date.Soon())
                .Generate(numberOfRecords);
        }
    }
}
