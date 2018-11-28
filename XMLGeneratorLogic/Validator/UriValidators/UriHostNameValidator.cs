using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneratorLogic.Validator.UriValidators
{
    public class UriHostNameValidator : IValidator<Uri>
    {
        private string message;
        public string Message => message;

        public UriHostNameValidator()
        {
            message = "Ok";
        }

        public bool IsValid(Uri value)
        {
            if (Uri.CheckHostName(value.Host) != UriHostNameType.Dns)
            {
                message = $"The uri {value} must contain host of dns type.";
                return false;
            }

            return true;
        }
    }
}
