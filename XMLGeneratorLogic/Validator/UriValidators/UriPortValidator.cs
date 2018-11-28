using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneratorLogic.Validator.UriValidators
{
    public class UriPortValidator : IValidator<Uri>
    {
        private readonly int DEFAULTHTTPPORT;
        private readonly int DEFAULTHTTSPPORT;

        private string message;
        public string Message => message;

        public UriPortValidator()
        {
            DEFAULTHTTPPORT = 80;
            DEFAULTHTTSPPORT = 443;
            message = "Ok";
        }

        public bool IsValid(Uri value)
        {
            if (value.Port != DEFAULTHTTPPORT || value.Port !=DEFAULTHTTSPPORT)
            {
                message = $"The uri {value} must not contain 'port'.";
                return false;
            }

            return true;
        }
    }
}
