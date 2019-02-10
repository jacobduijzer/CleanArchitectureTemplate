using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Shared
{
    public interface IRepository<TEntity> 
        : IReadOnlyRepository<TEntity> 
            where TEntity : BaseEntity
    {
        Task UpdateAsync(TEntity updatedItem);
    }
}
