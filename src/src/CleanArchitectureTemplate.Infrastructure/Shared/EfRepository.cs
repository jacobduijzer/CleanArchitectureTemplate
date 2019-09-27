using System;
using CleanArchitectureTemplate.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Infrastructure.Shared
{
    public class EfRepository<TEntity> : IRepository<TEntity>
            where TEntity : Entity
    {
        private readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext appDbContext) =>
            _dbContext = appDbContext;

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate) =>
            await _dbContext
            .Set<TEntity>()
            .Where(predicate)
            .ToListAsync()
            .ConfigureAwait(false);

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate) =>
            await _dbContext
            .Set<TEntity>()
            .Where(predicate)
            .CountAsync()
            .ConfigureAwait(false);

        public async Task<TEntity> SingleItemAsync(Expression<Func<TEntity, bool>> predicate) =>
            await _dbContext
            .Set<TEntity>()
            .Where(predicate)
            .SingleOrDefaultAsync()
            .ConfigureAwait(false);

        public async Task<TEntity> FirstItemAsync(Expression<Func<TEntity, bool>> predicate) =>
            await _dbContext
            .Set<TEntity>()
            .Where(predicate)
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);

        public async Task InsertAsync(TEntity entity)
        {
            await _dbContext
                .Set<TEntity>()
                .AddAsync(entity)
                .ConfigureAwait(false);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task InsertOrUpdateAsync(TEntity entity)
        {
            if (await _dbContext.Set<TEntity>().ContainsAsync(entity).ConfigureAwait(false))
                await UpdateAsync(entity).ConfigureAwait(false);
            else
                await InsertAsync(entity).ConfigureAwait(false);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (_dbContext.Set<TEntity>().Local.Contains(entity))
                _dbContext.Set<TEntity>().Local.Remove(entity);

            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
