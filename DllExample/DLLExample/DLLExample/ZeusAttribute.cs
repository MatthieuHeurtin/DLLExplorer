using System;

namespace DLLExample
{

    public class ZeusAttribute :Attribute
    {

        public string Description { get; set; }

        public ZeusAttribute(string desc)
        {
            Description = desc;
        }
    }
}
