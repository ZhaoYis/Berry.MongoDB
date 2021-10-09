using System;

namespace Berry.MongoDB
{
    /// <summary>
    /// MongoBasicInfo
    /// </summary>
    public class MongoBasicInfo : IMongoBasicInfo
    {
        public Type EntityType { get; set; }

        public string CollectionName { get; set; }

        public string DatabaseName { get; set; }

        public string BucketName { get; set; }
    }
}
