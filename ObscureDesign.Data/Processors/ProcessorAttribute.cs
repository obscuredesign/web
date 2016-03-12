using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObscureDesign.Processors
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ProcessorAttribute : Attribute
    {
        public ProcessorAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
