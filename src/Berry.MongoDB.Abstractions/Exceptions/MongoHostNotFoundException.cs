using System;

namespace Berry.MongoDB.Exceptions
{
    public class MongoHostNotFoundException : Exception
    {
        public MongoHostNotFoundException() : base("No available MongoDB host address found.")
        {
        }
    }
}
