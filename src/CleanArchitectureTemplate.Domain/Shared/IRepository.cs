using System.Collections.Generic;
using System.Threading.Tasks;
using LinqBuilder.Core;

namespace CleanArchitectureTemplate.Domain.Shared
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetItemsAsync(ISpecification<TEntity> specification);

        Task<int> GetItemCountAsync(ISpecification<TEntity> specification);

        Task<TEntity> GetSingleItemAsync(ISpecification<TEntity> specification);

        Task<TEntity> GetFirstItemAsync(ISpecification<TEntity> specification);

        Task UpdateAsync(TEntity updatedItem);
    }
}
