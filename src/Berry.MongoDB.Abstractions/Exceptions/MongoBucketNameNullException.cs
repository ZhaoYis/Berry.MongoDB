using System;

namespace Berry.MongoDB.Exceptions
{
    public class MongoBucketNameNullException : ArgumentNullException
    {
        public MongoBucketNameNullException(string bucketName) : base(bucketName)
        {
        }
    }
}
