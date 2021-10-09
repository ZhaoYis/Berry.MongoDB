using Berry.MongoDB.Abstractions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Berry.MongoDB.Repositories
{
    /// <summary>
    /// IMongoReadOnlyBasicRepository
    /// </summary>
    public interface IMongoReadOnlyBasicRepository<T> : IMongoRepository where T : IMongoDocument
    {
        Task<bool> ExistAsync([NotNull] Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);

        Task<List<T>> GetListAsync(CancellationToken cancellationToken = default);

        Task<List<T>> GetListAsync([NotNull] Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);

        Task<List<TResult>> GetListAsync<TResult>([NotNull] Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> projection, CancellationToken cancellationToken = default);

        Task<List<T>> GetListAsync([NotNull] Expression<Func<T, bool>> predicate,
            SortDefinition<T> sort, int limit, CancellationToken cancellationToken = default);

        Task<List<T>> GetListAsync([NotNull] Expression<Func<T, bool>> predicate,
            SortDefinition<T> sort, int limit, int skip, CancellationToken cancellationToken = default);

        Task<List<TResult>> GetListAsync<TResult>([NotNull] Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> projection, SortDefinition<T> sort, int limit,
            CancellationToken cancellationToken = default);

        Task<List<TResult>> GetListAsync<TResult>([NotNull] Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> projection, SortDefinition<T> sort, int limit, int skip,
            CancellationToken cancellationToken = default);
    }
}
