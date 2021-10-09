using Berry.MongoDB.Abstractions;
using Berry.MongoDB.Attributes;
using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace Berry.MongoDB
{
    /// <summary>
    /// MongoBasicInfoHelper
    /// </summary>
    public static class MongoBasicInfoHelper
    {
        private static readonly ConcurrentDictionary<Type, IMongoBasicInfo> MongoBasicInfoCache = new ConcurrentDictionary<Type, IMongoBasicInfo>();

        public static IMongoBasicInfo TryGetMongoBasicInfo<T>() where T : IMongoDocument
        {
            Type type = typeof(T);

            if (MongoBasicInfoCache.ContainsKey(type))
            {
                return MongoBasicInfoCache[type];
            }
            else
            {
                IMongoBasicInfo model = GetMongoBasicInfo(type);

                MongoBasicInfoCache[type] = model;

                return model;
            }
        }

        private static IMongoBasicInfo GetMongoBasicInfo(Type type)
        {
            //database name.
            MongoDatabaseNameAttribute databaseNameAttribute = type.GetCustomAttribute<MongoDatabaseNameAttribute>();
            string databaseName = null;
            if (databaseNameAttribute != null && !string.IsNullOrEmpty(databaseNameAttribute.DatabaseName))
            {
                databaseName = databaseNameAttribute.DatabaseName;
            }

            //collection name.
            MongoCollectionNameAttribute collectionNameAttribute = type.GetCustomAttribute<MongoCollectionNameAttribute>();
            string collectionName = type.Name;
            if (collectionNameAttribute != null && !string.IsNullOrEmpty(collectionNameAttribute.CollectionName))
            {
                collectionName = collectionNameAttribute.CollectionName;
            }

            //bucket name.
            MongoBucketNameAttribute bucketNameAttribute = type.GetCustomAttribute<MongoBucketNameAttribute>();
            string bucketName = type.Name + "_Bucket";
            if (bucketNameAttribute != null && !string.IsNullOrEmpty(bucketNameAttribute.BucketName))
            {
                bucketName = bucketNameAttribute.BucketName;
            }

            return new MongoBasicInfo
            {
                EntityType = type,
                DatabaseName = databaseName,
                CollectionName = collectionName,
                BucketName = bucketName
            };
        }
    }
}
