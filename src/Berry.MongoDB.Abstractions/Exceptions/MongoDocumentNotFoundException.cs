using System;

namespace Berry.MongoDB.Exceptions
{
    public class MongoDocumentNotFoundException : Exception
    {
        public MongoDocumentNotFoundException(Type entityType)
            : base($"Document of type {entityType.FullName} not found.")
        {
        }

        public MongoDocumentNotFoundException(Type entityType, object id)
            : base($"Document with ID={id} and type {entityType.FullName} not found.")
        {
        }
    }
}
