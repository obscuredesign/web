using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObscureDesign.Processors
{
    public interface IProcessor
    {
        string Process(string source);
    }

    public interface IProcessor<T> : IProcessor
        where T : IProcessor, new()
    {

    }

    public interface IPostprocessor : IProcessor
    {

    }

    public interface IPreprocessor : IProcessor
    {

    }
}
