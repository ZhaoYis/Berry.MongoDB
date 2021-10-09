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
    /// IMongoBasicRepository
    /// </summary>
    public interface IMongoBasicRepository<T> : IMongoReadOnlyRepository<T> where T : IMongoDocument
    {
        Task<T> InsertAsync([NotNull] T entity, CancellationToken cancellationToken = default);

        Task InsertManyAsync([NotNull] IEnumerable<T> entities, CancellationToken cancellationToken = default);

        Task<T> ReplaceAsync([NotNull] Expression<Func<T, bool>> predicate, [NotNull] T entity,
            CancellationToken cancellationToken = default);

        Task UpdateAsync([NotNull] Expression<Func<T, bool>> predicate,
            Func<UpdateDefinitionBuilder<T>, UpdateDefinition<T>> update,
            CancellationToken cancellationToken = default);

        Task UpdateManyAsync([NotNull] Expression<Func<T, bool>> predicate,
            Func<UpdateDefinitionBuilder<T>, UpdateDefinition<T>> update,
            CancellationToken cancellationToken = default);

        Task DeleteAsync([NotNull] Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task DeleteManyAsync([NotNull] Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);
    }
}
