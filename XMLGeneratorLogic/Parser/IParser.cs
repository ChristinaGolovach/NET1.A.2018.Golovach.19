using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneratorLogic.Parser
{
    public interface IParser<in TInput, out TOutput>
    {
        TOutput Parse(TInput value);
    }
}
