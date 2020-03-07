using CleanArchitectureTemplate.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore.Internal;

namespace CleanArchitectureTemplate.FakeData.ToDoItems
{
    public static class TestDataExtension
    {
        public static void Seed(this AppDbContext dbContext)
        {
#if IncludeSampleCode
            if (!dbContext.ToDoItems.Any())
            {
                dbContext.ToDoItems.AddRange(ToDoItemData.GenerateTestData(100));
                dbContext.SaveChanges();
            }
#endif
        }
    }
}