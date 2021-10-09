using Berry.MongoDB.Abstractions;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Berry.MongoDB.Repositories
{
    /// <summary>
    /// IMongoRepository
    /// </summary>
    public interface IMongoRepository<T> : IMongoBasicRepository<T>, IMongoRepository where T : IMongoDocument
    {
        Task<T> FindAsync([NotNull] Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<TResult> FindAsync<TResult>([NotNull] Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> projection,
            CancellationToken cancellationToken = default);

        Task<T> GetAsync([NotNull] Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<TResult> GetAsync<TResult>([NotNull] Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> projection,
            CancellationToken cancellationToken = default);
    }
}
