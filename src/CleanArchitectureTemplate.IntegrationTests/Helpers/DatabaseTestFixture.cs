using System;
using CleanArchitectureTemplate.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.IntegrationTests.Helpers
{
    public class DatabaseTestFixture
    {
        public readonly AppDbContext AppDbContext;

        public DatabaseTestFixture()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                 .UseInMemoryDatabase(databaseName: "in-mem-api-test-database")
                 .Options;

            AppDbContext = new AppDbContext(options);

            //dbContext.Beers.AddRange(BeerData.Beers);
            //dbContext.SaveChanges();
        }
    }
}
