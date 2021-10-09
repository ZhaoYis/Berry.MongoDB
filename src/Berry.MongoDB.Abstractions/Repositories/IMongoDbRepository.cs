using Berry.MongoDB.Abstractions;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace Berry.MongoDB.Repositories
{
    /// <summary>
    /// IMongoDbRepository
    /// </summary>
    public interface IMongoDbRepository<T> : IMongoRepository<T> where T : IMongoDocument
    {
        Task<IMongoDatabase> GetDatabaseAsync(ReadPreferenceMode mode = ReadPreferenceMode.SecondaryPreferred,
            ReadConcernLevel level = ReadConcernLevel.Majority, CancellationToken cancellationToken = default);

        Task<IMongoCollection<T>> GetCollectionAsync(ReadPreferenceMode mode = ReadPreferenceMode.SecondaryPreferred,
            ReadConcernLevel level = ReadConcernLevel.Majority, CancellationToken cancellationToken = default);

        Task<IAggregateFluent<T>> GetAggregateAsync(ReadPreferenceMode mode = ReadPreferenceMode.SecondaryPreferred,
            ReadConcernLevel level = ReadConcernLevel.Majority, CancellationToken cancellationToken = default);
    }
}
