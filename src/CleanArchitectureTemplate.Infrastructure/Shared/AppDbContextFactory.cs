using CleanArchitectureTemplate.FakeData.ToDoItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CleanArchitectureTemplate.Infrastructure.Shared
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // TODO: remove this and the nuget package from this project and add a real provider
            optionsBuilder.UseInMemoryDatabase("in-mem-test-database");
            var dbContext = new AppDbContext(optionsBuilder.Options);
            dbContext.ToDoItems.AddRange(ToDoItemData.ToDoItems);
            dbContext.SaveChanges();

            return dbContext;
        }
    }
}
