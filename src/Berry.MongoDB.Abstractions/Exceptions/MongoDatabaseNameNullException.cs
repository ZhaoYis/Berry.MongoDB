using System;

namespace Berry.MongoDB.Exceptions
{
    public class MongoDatabaseNameNullException : ArgumentNullException
    {
        public MongoDatabaseNameNullException(string paramName) : base(paramName)
        {
        }
    }
}
