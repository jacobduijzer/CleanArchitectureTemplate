using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Shared
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleItemAsync(Expression<Func<TEntity, bool>> predicate);

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task InsertOrUpdateAsync(TEntity entity);
    }
}
