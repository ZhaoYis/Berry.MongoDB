using Berry.MongoDB.Abstractions;
using Berry.MongoDB.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Berry.MongoDB.Repositories
{
    /// <summary>
    /// MongoDbRepository
    /// </summary>
    public class MongoDbRepository<T> : MongoRepositoryBase<T>, IMongoDbRepository<T> where T : IMongoDocument
    {
        #region ctor

        private IMongoDbClient MongoDbClient { get; }

        private MongoDbOptions Options { get; }

        public MongoDbRepository(IMongoDbClient mongoDbClient, IOptions<MongoDbOptions> options)
        {
            this.MongoDbClient = mongoDbClient;
            this.Options = options.Value;
        }

        #endregion

        #region Insert

        public override async Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default)
        {
            var collection =
                await this.GetCollectionAsync(mode: ReadPreferenceMode.Primary, cancellationToken: cancellationToken);

            await collection.InsertOneAsync(entity, cancellationToken: cancellationToken);

            return entity;
        }

        public override async Task InsertManyAsync(IEnumerable<T> entities,
            CancellationToken cancellationToken = default)
        {
            var collection =
                await this.GetCollectionAsync(mode: ReadPreferenceMode.Primary, cancellationToken: cancellationToken);

            await collection.InsertManyAsync(entities, cancellationToken: cancellationToken);
        }

        #endregion

        #region Delete

        public override async Task DeleteAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            var collection =
                await this.GetCollectionAsync(mode: ReadPreferenceMode.Primary, cancellationToken: cancellationToken);

            await collection.DeleteOneAsync(predicate, cancellationToken: cancellationToken);
        }

        public override async Task DeleteManyAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            var collection =
                await this.GetCollectionAsync(mode: ReadPreferenceMode.Primary, cancellationToken: cancellationToken);

            await collection.DeleteManyAsync(predicate, cancellationToken: cancellationToken);
        }

        #endregion

        #region Query

        public override async Task<bool> ExistAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            var collection =
                await this.GetCollectionAsync(ReadPreferenceMode.Primary, cancellationToken: cancellationToken);

            bool exist = await collection
                .Find(predicate)
                .AnyAsync(cancellationToken);

            return exist;
        }

        public override async Task<List<T>> GetListAsync(CancellationToken cancellationToken = default)
        {
            var queryable = await this.GetMongoQueryableAsync(cancellationToken: cancellationToken);

            var documents = await queryable.ToListAsync(cancellationToken);

            return documents;
        }

        public override async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            var collection = await this.GetCollectionAsync(cancellationToken: cancellationToken);

            var documents = await collection
                .Find(predicate)
                .ToListAsync(cancellationToken);

            return documents;
        }

        public override async Task<List<TResult>> GetListAsync<TResult>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> projection, CancellationToken cancellationToken = default)
        {
            var collection = await this.GetCollectionAsync(cancellationToken: cancellationToken);

            var documents = await collection
                .Find(predicate)
                .Project(projection)
                .ToListAsync(cancellationToken);

            return documents;
        }

        public override async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate,
            SortDefinition<T> sort, int limit,
            CancellationToken cancellationToken = default)
        {
            var collection = await this.GetCollectionAsync(cancellationToken: cancellationToken);

            var documents = await collection
                .Find(predicate)
                .Sort(sort)
                .Limit(limit)
                .ToListAsync(cancellationToken);

            return documents;
        }

        public override async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, SortDefinition<T> sort,
            int limit, int skip,
            CancellationToken cancellationToken = default)
        {
            var collection = await this.GetCollectionAsync(cancellationToken: cancellationToken);

            var documents = await collection
                .Find(predicate)
                .Sort(sort)
                .Limit(limit)
                .Skip(skip)
                .ToListAsync(cancellationToken);

            return documents;
        }

        public override async Task<List<TResult>> GetListAsync<TResult>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> projection, SortDefinition<T> sort, int limit,
            CancellationToken cancellationToken = default)
        {
            var collection = await this.GetCollectionAsync(cancellationToken: cancellationToken);

            var documents = await collection
                .Find(predicate)
                .Project(projection)
                .Sort(sort)
                .Limit(limit)
                .ToListAsync(cancellationToken);

            return documents;
        }

        public override async Task<List<TResult>> GetListAsync<TResult>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> projection, SortDefinition<T> sort, int limit, int skip,
            CancellationToken cancellationToken = default)
        {
            var collection = await this.GetCollectionAsync(cancellationToken: cancellationToken);

            var documents = await collection
                .Find(predicate)
                .Project(projection)
                .Sort(sort)
                .Limit(limit)
                .Skip(skip)
                .ToListAsync(cancellationToken);

            return documents;
        }

        public override async Task<T> FindAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            var collection = await this.GetCollectionAsync(cancellationToken: cancellationToken);

            var document = await collection
                .Find(predicate)
                .FirstOrDefaultAsync(cancellationToken);

            return document;
        }

        public override async Task<TResult> FindAsync<TResult>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> projection, CancellationToken cancellationToken = default)
        {
            var collection = await this.GetCollectionAsync(cancellationToken: cancellationToken);

            var document = await collection
                .Find(predicate)
                .Project(projection)
                .FirstOrDefaultAsync(cancellationToken);

            return document;
        }

        #endregion

        #region Update

        public override async Task<T> ReplaceAsync(Expression<Func<T, bool>> predicate, T entity,
            CancellationToken cancellationToken = default)
        {
            var collection =
                await this.GetCollectionAsync(mode: ReadPreferenceMode.Primary, cancellationToken: cancellationToken);

            await collection.ReplaceOneAsync(predicate, entity, cancellationToken: cancellationToken);

            return entity;
        }

        public override async Task UpdateAsync(Expression<Func<T, bool>> predicate,
            Func<UpdateDefinitionBuilder<T>, UpdateDefinition<T>> update,
            CancellationToken cancellationToken = default)
        {
            var collection =
                await this.GetCollectionAsync(mode: ReadPreferenceMode.Primary, cancellationToken: cancellationToken);

            var updates = Builders<T>.Update;

            await collection.UpdateOneAsync(predicate, update(updates), cancellationToken: cancellationToken);
        }

        public override async Task UpdateManyAsync(Expression<Func<T, bool>> predicate,
            Func<UpdateDefinitionBuilder<T>, UpdateDefinition<T>> update,
            CancellationToken cancellationToken = default)
        {
            var collection =
                await this.GetCollectionAsync(mode: ReadPreferenceMode.Primary, cancellationToken: cancellationToken);

            var updates = Builders<T>.Update;

            await collection.UpdateManyAsync(predicate, update(updates), cancellationToken: cancellationToken);
        }

        #endregion

        #region Basic

        public Task<IMongoDatabase> GetDatabaseAsync(ReadPreferenceMode mode = ReadPreferenceMode.SecondaryPreferred,
            ReadConcernLevel level = ReadConcernLevel.Majority, CancellationToken cancellationToken = default)
        {
            var database = this.MongoDbClient.Database<T>(mode, level);

            return Task.FromResult<IMongoDatabase>(database);
        }

        public Task<IMongoCollection<T>> GetCollectionAsync(
            ReadPreferenceMode mode = ReadPreferenceMode.SecondaryPreferred,
            ReadConcernLevel level = ReadConcernLevel.Majority, CancellationToken cancellationToken = default)
        {
            var collection = this.MongoDbClient.Collection<T>(mode, level);

            return Task.FromResult<IMongoCollection<T>>(collection);
        }

        public Task<IAggregateFluent<T>> GetAggregateAsync(
            ReadPreferenceMode mode = ReadPreferenceMode.SecondaryPreferred,
            ReadConcernLevel level = ReadConcernLevel.Majority, CancellationToken cancellationToken = default)
        {
            var collection = this.MongoDbClient.Collection<T>(mode, level);

            var aggregate = collection.Aggregate();

            return Task.FromResult<IAggregateFluent<T>>(aggregate);
        }

        public override async Task<IQueryable<T>> GetQueryableAsync(CancellationToken cancellationToken = default)
        {
            return await this.GetMongoQueryableAsync(cancellationToken: cancellationToken);
        }

        private Task<IMongoQueryable<T>> GetMongoQueryableAsync(
            ReadPreferenceMode mode = ReadPreferenceMode.SecondaryPreferred,
            ReadConcernLevel level = ReadConcernLevel.Majority, CancellationToken cancellationToken = default)
        {
            var collection = this.MongoDbClient.Collection<T>(mode, level);

            var queryable = collection.AsQueryable();

            return Task.FromResult<IMongoQueryable<T>>(queryable);
        }

        #endregion
    }
}
