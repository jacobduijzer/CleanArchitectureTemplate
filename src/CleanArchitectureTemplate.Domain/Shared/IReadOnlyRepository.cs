using LinqBuilder.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Shared
{
    public interface IReadOnlyRepository<TEntity>
        where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> GetItemsAsync(ICacheableDataSpecification<TEntity> specification);

        Task<int> GetItemCountAsync(ICacheableDataSpecification<TEntity> specification);

        Task<TEntity> GetSingleItemAsync(ICacheableDataSpecification<TEntity> specification);

        Task<TEntity> GetFirstItemAsync(ICacheableDataSpecification<TEntity> specification);
    }
}
