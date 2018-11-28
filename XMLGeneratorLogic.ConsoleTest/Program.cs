using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLGeneratorLogic.DataProvider;
using XMLGeneratorLogic.Mapper;
using XMLGeneratorLogic.Parser;
using XMLGeneratorLogic.Logger;
using XMLGeneratorLogic.Validator.UriValidators;
using XMLGeneratorLogic.XMLGenerator;
using XMLGeneratorLogic.Storage;

namespace XMLGeneratorLogic.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLFileStorage fileStorage = new XMLFileStorage("data.xml");
            UriInStringFormatDataProvider dataProvider = new UriInStringFormatDataProvider("data.txt");
            XMLGeneratorForURISchemeHostPathParameters xMLGeneratorForURISchemeHostPathParameters = new XMLGeneratorForURISchemeHostPathParameters();

            StringToUriParser stringToUriParser = new StringToUriParser();
            UriHostNameValidator uriHostNameValidator = new UriHostNameValidator();
            NLogger logger = new NLogger();
            UriMapper upiMapper = new UriMapper(stringToUriParser, uriHostNameValidator, logger);

            Processor processor = new Processor(dataProvider, upiMapper, xMLGeneratorForURISchemeHostPathParameters, fileStorage);
            processor.ConvertData();
        }
    }
}
