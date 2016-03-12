using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObscureDesign.Processors
{
    public class CopyContent : IProcessor, IPreprocessor, IPostprocessor
    {
        public CopyContent() { }
        public string Process(string source) => source;
    }
}
