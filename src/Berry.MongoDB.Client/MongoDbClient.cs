using Berry.MongoDB.Abstractions;
using Berry.MongoDB.Configurations;
using Berry.MongoDB.Exceptions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Berry.MongoDB
{
    /// <summary>
    /// MongoDbClient
    /// </summary>
    public class MongoDbClient : IMongoDbClient
    {
        #region ctor

        private MongoDbOptions Options { get; }

        public IMongoClient Client { get; }

        public MongoDbClient(IOptions<MongoDbOptions> options)
        {
            this.Options = options.Value;
            this.Client = new MongoClient(this.Options.ToString());
        }

        #endregion

        #region public methods

        #region Collection

        public IMongoCollection<T> Collection<T>(ReadPreferenceMode mode, ReadConcernLevel level)
            where T : IMongoDocument
        {
            MongoCollectionSettings settings = new MongoCollectionSettings
            {
                ReadPreference = new ReadPreference(mode),
                ReadConcern = new ReadConcern(level),
                WriteConcern = WriteConcern.WMajority
            };

            return this.Collection<T>(this.GetCollectionName<T>(), settings);
        }

        public IMongoCollection<T> Collection<T>(string collectionName,
            MongoCollectionSettings settings) where T : IMongoDocument
        {
            return this.Collection<T>(collectionName, this.GetDatabaseName<T>(), settings);
        }

        public IMongoCollection<T> Collection<T>(string collectionName, string databaseName,
            MongoCollectionSettings settings) where T : IMongoDocument
        {
            if (string.IsNullOrEmpty(collectionName))
            {
                throw new MongoCollectionNameNullException(nameof(collectionName));
            }

            IMongoDatabase db = this.Database<T>(databaseName);

            return db.GetCollection<T>(collectionName, settings);
        }

        #endregion

        #region Database

        public IMongoDatabase Database<T>(ReadPreferenceMode mode, ReadConcernLevel level) where T : IMongoDocument
        {
            return this.Database<T>(this.GetDatabaseName<T>(), mode, level);
        }

        public IMongoDatabase Database<T>(string databaseName,
            ReadPreferenceMode mode = ReadPreferenceMode.SecondaryPreferred,
            ReadConcernLevel level = ReadConcernLevel.Majority) where T : IMongoDocument
        {
            MongoDatabaseSettings settings = new MongoDatabaseSettings()
            {
                ReadPreference = new ReadPreference(mode),
                ReadConcern = new ReadConcern(level),
                WriteConcern = WriteConcern.WMajority
            };

            return this.Database<T>(databaseName, settings);
        }

        public IMongoDatabase Database<T>(string databaseName, MongoDatabaseSettings settings) where T : IMongoDocument
        {
            if (string.IsNullOrEmpty(databaseName))
            {
                throw new MongoDatabaseNameNullException(nameof(databaseName));
            }

            IMongoDatabase db = this.Client.GetDatabase(databaseName, settings);

            return db;
        }

        #endregion

        #region GridFS

        public IGridFSBucket GridFSBucket<T>(ReadPreferenceMode mode = ReadPreferenceMode.SecondaryPreferred,
            ReadConcernLevel level = ReadConcernLevel.Majority)
            where T : IMongoDocument
        {
            GridFSBucketOptions options = new GridFSBucketOptions
            {
                BucketName = this.GetBucketName<T>(),
                ChunkSizeBytes = this.Options.GridFSOptions.ChunkSizeBytes, //块大小（以字节为单位）。默认1MB
                ReadPreference = new ReadPreference(mode),
                ReadConcern = new ReadConcern(level),
                WriteConcern = WriteConcern.WMajority
            };

            return this.GridFSBucket<T>(options);
        }

        public IGridFSBucket GridFSBucket<T>(GridFSBucketOptions options) where T : IMongoDocument
        {
            IMongoDatabase db = this.Database<T>(this.GetDatabaseName<T>());

            IGridFSBucket bucket = new GridFSBucket(db, options);

            return bucket;
        }

        #endregion

        #endregion

        #region private methods.

        private string GetCollectionName<T>() where T : IMongoDocument
        {
            return this.GetMongoBasicInfo<T>().CollectionName;
        }

        private string GetDatabaseName<T>() where T : IMongoDocument
        {
            return this.GetMongoBasicInfo<T>().DatabaseName;
        }

        private string GetBucketName<T>() where T : IMongoDocument
        {
            return this.GetMongoBasicInfo<T>().BucketName;
        }

        private IMongoBasicInfo GetMongoBasicInfo<T>() where T : IMongoDocument
        {
            IMongoBasicInfo model = MongoBasicInfoHelper.TryGetMongoBasicInfo<T>();

            model.DatabaseName = model.DatabaseName ?? this.Options.DefaultDatabaseName;

            return model;
        }

        #endregion
    }
}
