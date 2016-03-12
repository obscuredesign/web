using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObscureDesign.Processors
{
    public abstract class ProcessorBase<T> : IProcessor<T>
        where T : IProcessor, new()
    {
        protected T PreviousProcessor { get; } = new T();

        public string Process(string source)
        {
            var intermediateResult = PreviousProcessor.Process(source);
            var result = ProcessImpl(intermediateResult);
            return result;
        }

        protected abstract string ProcessImpl(string source);
    }
}
