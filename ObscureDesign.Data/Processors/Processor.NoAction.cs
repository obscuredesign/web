using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObscureDesign.Processors
{
    [Processor("None")]
    public class NoAction<T> : ProcessorBase<T>, IPostprocessor
        where T : IProcessor, new()
    {
        protected override string ProcessImpl(string source)
        {
            return source;
        }
    }
}
