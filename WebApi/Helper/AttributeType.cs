using System;

namespace WebApi.Helper
{
    public class AttributeType : Attribute
    {
        public bool PrimaryKey { get; set; }
        public bool ForeignKey { get; set; }
    }

    public class AutoIncrement : Attribute
    {
        public bool Auto { get; set; }
    }
}