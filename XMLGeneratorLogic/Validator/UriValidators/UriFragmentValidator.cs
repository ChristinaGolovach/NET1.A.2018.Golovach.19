using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneratorLogic.Validator.UriValidators
{
    public class UriFragmentValidator : IValidator<Uri>
    {
        private string message;
        public string Message => message;

        public UriFragmentValidator()
        {
            message = "Ok";
        }

        public bool IsValid(Uri value)
        {
            if (value.Fragment != "")
            {
                message = $"The uri {value} must not contain 'fragment'.";
                return false;
            }

            return true;
        }
    }
}
