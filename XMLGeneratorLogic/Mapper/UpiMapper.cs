using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLGeneratorLogic.Parser;
using XMLGeneratorLogic.Validator;
using XMLGeneratorLogic.Logger;

namespace XMLGeneratorLogic.Mapper
{
    public class UpiMapper : IMapper<string, Uri>
    {
        private IValidator<Uri> uriValidator;
        private IParser<string, Uri> stringToUriParser;
        private ILogger logger;

        public UpiMapper(IParser<string, Uri> stringToUriParser, IValidator<Uri> uriValidator, ILogger logger)
        {
            this.stringToUriParser = stringToUriParser;
            this.uriValidator = uriValidator;
            this.logger = logger;
        }

        public Uri Map(string value)
        {
            Uri uri = stringToUriParser.Parse(value);

            if (uri == null)
            {
                logger.Log($"The line {value} is not processed.");

                return null;
            }

            bool uriValidationResult = uriValidator.IsValid(uri);

            if (!uriValidationResult)
            {
                logger.Log($"The line {value} is not processed - {uriValidator.Message}");

                return null;
            }

            return uri;
        }
    }
}
