using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneratorLogic.Validator.UriValidators
{
    //TOD Message and abstract class
    public class UriDefaultValidator : IValidator<Uri>
    {
        private string message;
        private IEnumerable<IValidator<Uri>> validators;

        public string Message => message;

        public UriDefaultValidator(IEnumerable<IValidator<Uri>> validators)
        {
            this.validators = validators;
        }                    

        //TODO 
        public bool IsValid(Uri value)
        {
            return validators.All(v => v.IsValid(value));            
        }
    }
}
