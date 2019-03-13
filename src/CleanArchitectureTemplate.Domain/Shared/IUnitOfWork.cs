using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Shared
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
