using Berry.MongoDB.Abstractions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Berry.MongoDB.Repositories
{
    /// <summary>
    /// MongoBasicRepositoryBase
    /// </summary>
    public abstract class MongoBasicRepositoryBase<T> : IMongoBasicRepository<T> where T : IMongoDocument
    {
        public abstract Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default);

        public abstract Task InsertManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        public abstract Task<bool> ExistAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);

        public abstract Task<List<T>> GetListAsync(CancellationToken cancellationToken = default);

        public abstract Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);

        public abstract Task<List<TResult>> GetListAsync<TResult>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> projection, CancellationToken cancellationToken = default);

        public abstract Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate,
            SortDefinition<T> sort,
            int limit,
            CancellationToken cancellationToken = default);

        public abstract Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, SortDefinition<T> sort,
            int limit,
            int skip,
            CancellationToken cancellationToken = default);

        public abstract Task<List<TResult>> GetListAsync<TResult>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> projection, SortDefinition<T> sort, int limit,
            CancellationToken cancellationToken = default);

        public abstract Task<List<TResult>> GetListAsync<TResult>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> projection, SortDefinition<T> sort, int limit, int skip,
            CancellationToken cancellationToken = default);

        public abstract Task<T> ReplaceAsync(Expression<Func<T, bool>> predicate, T entity,
            CancellationToken cancellationToken = default);

        public abstract Task UpdateAsync(Expression<Func<T, bool>> predicate,
            Func<UpdateDefinitionBuilder<T>, UpdateDefinition<T>> updatePredicate,
            CancellationToken cancellationToken = default);

        public abstract Task UpdateManyAsync(Expression<Func<T, bool>> predicate,
            Func<UpdateDefinitionBuilder<T>, UpdateDefinition<T>> update,
            CancellationToken cancellationToken = default);

        public abstract Task DeleteAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);

        public abstract Task DeleteManyAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);

        public abstract Task<IQueryable<T>> GetQueryableAsync(CancellationToken cancellationToken = default);
    }
}
