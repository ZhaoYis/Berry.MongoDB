using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Berry.MongoDB.Abstractions
{
    /// <summary>
    /// Customize a MongoDb client.
    /// </summary>
    public interface IMongoDbClient
    {
        IMongoClient Client { get; }

        IMongoCollection<T> Collection<T>(ReadPreferenceMode mode, ReadConcernLevel level) where T : IMongoDocument;

        IMongoCollection<T> Collection<T>(string collectionName, MongoCollectionSettings settings)
            where T : IMongoDocument;

        IMongoCollection<T> Collection<T>(string collectionName, string databaseName, MongoCollectionSettings settings)
            where T : IMongoDocument;

        IMongoDatabase Database<T>(ReadPreferenceMode mode, ReadConcernLevel level) where T : IMongoDocument;

        IMongoDatabase Database<T>(string databaseName, ReadPreferenceMode mode, ReadConcernLevel level)
            where T : IMongoDocument;

        IMongoDatabase Database<T>(string databaseName, MongoDatabaseSettings settings) where T : IMongoDocument;

        IGridFSBucket GridFSBucket<T>(ReadPreferenceMode mode, ReadConcernLevel level) where T : IMongoDocument;

        IGridFSBucket GridFSBucket<T>(GridFSBucketOptions options) where T : IMongoDocument;
    }
}
