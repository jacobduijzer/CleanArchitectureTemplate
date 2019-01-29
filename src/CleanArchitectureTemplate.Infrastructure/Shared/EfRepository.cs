using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Domain.Shared;
using LinqBuilder.Core;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Infrastructure.Shared
{
    public class EfRepository<TEntity> : IRepository<TEntity>
         where TEntity : BaseEntity
    {
        private readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext appDbContext) =>
            _dbContext = appDbContext;

        public async Task<IEnumerable<TEntity>> GetItemsAsync(ISpecification<TEntity> specification) =>
            await _dbContext.Set<TEntity>().ExeSpec(specification).ToListAsync().ConfigureAwait(false);

        public async Task<TEntity> GetSingleItemAsync(ISpecification<TEntity> specification) =>
            await _dbContext.Set<TEntity>().ExeSpec(specification).SingleOrDefaultAsync().ConfigureAwait(false);

        public async Task<TEntity> GetFirstItemAsync(ISpecification<TEntity> specification) =>
            await _dbContext.Set<TEntity>().ExeSpec(specification).FirstOrDefaultAsync().ConfigureAwait(false);

        public async Task UpdateAsync(TEntity updatedItem)
        {
            throw new System.NotImplementedException();
        }
    }
}
