using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneratorLogic.Validator.UriValidators
{
    public class UriSchemeValidator : IValidator<Uri>
    {
        private string mesage;
        public string Message => mesage;

        public UriSchemeValidator()
        {
            mesage = "Ok";
        }

        public bool IsValid(Uri value)
        {
            if (value.Scheme != Uri.UriSchemeHttp || value.Scheme != Uri.UriSchemeHttps)
            {
                mesage = $"The uri {value} must contain a scheme of http or https type.";
                return false;
            }

            return true;
        }
    }
}
