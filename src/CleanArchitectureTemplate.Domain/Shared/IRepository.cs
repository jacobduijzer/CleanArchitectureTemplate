using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Shared
{
    public interface IRepository<TEntity>
        : IReadOnlyRepository<TEntity>
            where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        Task UpdateAsync(TEntity updatedItem);

        Task InsertItemAsync(TEntity newItem);
    }
}
