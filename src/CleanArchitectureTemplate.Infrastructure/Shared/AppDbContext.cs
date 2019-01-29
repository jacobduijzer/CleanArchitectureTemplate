using CleanArchitectureTemplate.Domain.ToDoItems;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Infrastructure.Shared
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        { }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
