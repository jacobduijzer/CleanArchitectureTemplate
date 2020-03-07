#if (IncludeSampleCode)
using CleanArchitectureTemplate.FakeData.ToDoItems;
#endif
using CleanArchitectureTemplate.Infrastructure.Shared;
using System.Linq;
namespace CleanArchitectureTemplate.IntegrationTests.Helpers
{
    public static class DataInitializer
    {

#if (IncludeSampleCode)
        public static void SeedToDoItemsTestData(this AppDbContext db)
        {
            if (!db.ToDoItems.Any())
            {
                db.AddRange(ToDoItemData.ToDoItemsForTesting);
                db.SaveChanges();
            }
        }
#else
        // public static void SeedItemsTestData(this AppDbContext db)
        // {
        //     if (!db.SomeTable.Any())
        //     {
        //         db.AddRange(FakeItems);
        //         db.SaveChanges();
        //     }
        // }
#endif

    }
}