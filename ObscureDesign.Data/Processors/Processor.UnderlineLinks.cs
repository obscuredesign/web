using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ObscureDesign.Processors
{
    [Processor("Underline hyperlinks")]
    public class UnderlineLinks<T> : ProcessorBase<T>, IPostprocessor
        where T : IProcessor, new()
    {
        protected override string ProcessImpl(string source)
        {
            var linkPattern = new Regex(@"https?:\/\/\S+"); //TODO: ignore http case
            var result = linkPattern.Replace(source, (Match m) => $"<u>{m.Value}</u>");
            return result;
        }
    }
}
