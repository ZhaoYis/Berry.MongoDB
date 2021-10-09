using Berry.MongoDB.Abstractions;
using Berry.MongoDB.Exceptions;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Berry.MongoDB.Repositories
{
    /// <summary>
    /// MongoRepositoryBase
    /// </summary>
    public abstract class MongoRepositoryBase<T> : MongoBasicRepositoryBase<T>, IMongoRepository<T> where T : IMongoDocument
    {
        public abstract Task<T> FindAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);

        public abstract Task<TResult> FindAsync<TResult>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> projection, CancellationToken cancellationToken = default);

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            var entity = await this.FindAsync(predicate, cancellationToken);

            if (entity == null)
            {
                throw new MongoDocumentNotFoundException(typeof(T));
            }

            return entity;
        }

        public async Task<TResult> GetAsync<TResult>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> projection, CancellationToken cancellationToken = default)
        {
            var entity = await this.FindAsync(predicate, projection, cancellationToken);

            if (entity == null)
            {
                throw new MongoDocumentNotFoundException(typeof(T));
            }

            return entity;
        }
    }
}
