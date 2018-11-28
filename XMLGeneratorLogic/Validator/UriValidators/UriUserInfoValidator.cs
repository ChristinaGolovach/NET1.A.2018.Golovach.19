using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneratorLogic.Validator.UriValidators
{
    class UriUserInfoValidator
    {
        private string mesage;
        public string Message => mesage;

        public UriUserInfoValidator()
        {
            mesage = "Ok";
        }

        public bool IsValid(Uri value)
        {
            if (value.UserInfo != "")
            {
                mesage = $"The uri {value} must not contain 'user info' part.";
                return false;
            }

            return true;
        }
    }
}
