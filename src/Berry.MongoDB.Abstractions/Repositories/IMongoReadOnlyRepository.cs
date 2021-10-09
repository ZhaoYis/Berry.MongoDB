using Berry.MongoDB.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Berry.MongoDB.Repositories
{
    /// <summary>
    /// IMongoReadOnlyRepository
    /// </summary>
    public interface IMongoReadOnlyRepository<T> : IMongoReadOnlyBasicRepository<T> where T : IMongoDocument
    {
        Task<IQueryable<T>> GetQueryableAsync(CancellationToken cancellationToken = default);
    }
}
