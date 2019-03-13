using CleanArchitectureTemplate.Domain.Shared;
using LinqBuilder.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Infrastructure.Shared
{
    public class EfRepository<TEntity>
        : IRepository<TEntity>
            where TEntity : Entity
    {
        private readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext appDbContext) =>
            _dbContext = appDbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        public async Task<IEnumerable<TEntity>> GetItemsAsync(ICacheableDataSpecification<TEntity> specification) =>
            await _dbContext
            .Set<TEntity>()
            .ExeSpec(specification.Specification)
            .ToListAsync()
            .ConfigureAwait(false);

        public async Task<int> GetItemCountAsync(ICacheableDataSpecification<TEntity> specification) =>
            await _dbContext
            .Set<TEntity>()
            .ExeSpec(specification.Specification)
            .CountAsync()
            .ConfigureAwait(false);

        public async Task<TEntity> GetSingleItemAsync(ICacheableDataSpecification<TEntity> specification) =>
            await _dbContext
            .Set<TEntity>()
            .ExeSpec(specification.Specification)
            .SingleOrDefaultAsync()
            .ConfigureAwait(false);

        public async Task<TEntity> GetFirstItemAsync(ICacheableDataSpecification<TEntity> specification) =>
            await _dbContext
            .Set<TEntity>()
            .ExeSpec(specification.Specification)
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);

        public async Task UpdateAsync(TEntity updatedItem)
        {
            throw new System.NotImplementedException();
        }

        public async Task InsertItemAsync(TEntity item) =>
           await _dbContext
               .Set<TEntity>()
               .AddAsync(item)
               .ConfigureAwait(false);
    }
}
