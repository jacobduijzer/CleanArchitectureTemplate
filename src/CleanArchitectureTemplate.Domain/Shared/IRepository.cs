using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Shared
{
    public interface IRepository<TEntity> 
        : IReadOnlyRepository<TEntity> 
            where TEntity : EntityBase
    {
        Task UpdateAsync(TEntity updatedItem);
    }
}
