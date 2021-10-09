using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Berry.MongoDB.Abstractions
{
    /// <summary>
    /// Used to identify a MongoDB document.
    /// </summary>
    public interface IMongoDocument
    {

    }

    public interface IMongoDocument<TKey> : IMongoDocument
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId] TKey Id { get; set; }
    }
}
