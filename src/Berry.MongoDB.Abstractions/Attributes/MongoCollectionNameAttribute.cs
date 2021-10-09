using System;

namespace Berry.MongoDB.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class MongoCollectionNameAttribute : Attribute
    {
        private readonly string _name;

        public string CollectionName
        {
            get
            {
                return _name;
            }
        }

        public MongoCollectionNameAttribute(string name)
        {
            _name = name;
        }
    }
}
