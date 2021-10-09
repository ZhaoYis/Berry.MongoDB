using System;

namespace Berry.MongoDB.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class MongoDatabaseNameAttribute : Attribute
    {
        private readonly string _name;

        public string DatabaseName
        {
            get
            {
                return _name;
            }
        }

        public MongoDatabaseNameAttribute(string name)
        {
            _name = name;
        }
    }
}
