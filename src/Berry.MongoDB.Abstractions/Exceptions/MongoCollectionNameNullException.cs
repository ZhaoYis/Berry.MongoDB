using System;

namespace Berry.MongoDB.Exceptions
{
    public class MongoCollectionNameNullException : ArgumentNullException
    {
        public MongoCollectionNameNullException(string collectionName) : base(collectionName)
        {
        }
    }
}
