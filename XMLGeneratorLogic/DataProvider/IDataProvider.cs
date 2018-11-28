using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneratorLogic.DataProvider
{
    public interface IDataProvider <out TOutput>
    {
        TOutput Provide();
    }
}
