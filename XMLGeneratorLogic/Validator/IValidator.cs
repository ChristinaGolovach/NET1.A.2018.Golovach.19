using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneratorLogic.Validator
{
    public interface IValidator<in TInput>
    {
        string Message { get; }
        bool IsValid(TInput value);
    }
}
