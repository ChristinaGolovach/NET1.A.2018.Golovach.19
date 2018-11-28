using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneratorLogic.XMLGenerator
{
    public interface IXMLGenerator<in TInput, out TOutput>
    {
        TOutput GenerateXML(TInput value);
    }
}
