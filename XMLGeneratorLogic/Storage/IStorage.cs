using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneratorLogic.Storage
{
    public interface IStorage<in TInput>
    {
        void Save(TInput dataForStore);
    }
}
