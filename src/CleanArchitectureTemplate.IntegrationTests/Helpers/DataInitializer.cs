using CleanArchitectureTemplate.FakeData.ToDoItems;
using CleanArchitectureTemplate.Infrastructure.Shared;
using System.Linq;
namespace CleanArchitectureTemplate.IntegrationTests.Helpers
{
    public static class DataInitializer
    {
        public static void SeedToDoItemsTestData(this AppDbContext db)
        {
            if (!db.ToDoItems.Any())
            {
                db.AddRange(ToDoItemData.ToDoItemsForTesting);
                db.SaveChanges();
            }
        }
    }
}