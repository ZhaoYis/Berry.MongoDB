using System;

namespace Berry.MongoDB.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class MongoBucketNameAttribute : Attribute
    {
        private readonly string _name;

        public string BucketName
        {
            get { return _name; }
        }

        public MongoBucketNameAttribute(string name)
        {
            _name = name;
        }
    }
}
