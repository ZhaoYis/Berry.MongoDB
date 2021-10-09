using System;

namespace Berry.MongoDB
{
    /// <summary>
    /// IMongoBasicInfo
    /// </summary>
    public interface IMongoBasicInfo
    {
        public Type EntityType { get; set; }

        public string CollectionName { get; set; }

        public string DatabaseName { get; set; }

        public string BucketName { get; set; }
    }
}
