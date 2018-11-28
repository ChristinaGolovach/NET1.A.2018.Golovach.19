using System;
using System.Collections.Generic;
using System.Xml.Linq;
using XMLGeneratorLogic.DataProvider;
using XMLGeneratorLogic.Mapper;
using XMLGeneratorLogic.Parser;
using XMLGeneratorLogic.Logger;
using XMLGeneratorLogic.Validator;
using XMLGeneratorLogic.Validator.UriValidators;
using XMLGeneratorLogic.XMLGenerator;
using XMLGeneratorLogic.Storage;
using Ninject.Modules;
using Ninject;

namespace XMLGeneratorLogic.ConsoleTest
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataProvider<ICollection<string>>>().To<UriInStringFormatDataProvider>().WithConstructorArgument("filePath", "data.txt");
            Bind<IStorage<XElement>>().To<XMLFileStorage>().WithConstructorArgument("path", "data.xml");
            Bind<IXMLGenerator<ICollection<Uri>, XElement>>().To<XMLGeneratorForURISchemeHostPathParameters>();
            Bind<IMapper<string, Uri>>().To<UriMapper>();
            Bind<IParser<string, Uri>>().To<StringToUriParser>();
            Bind<IValidator<Uri>>().To<UriHostNameValidator>();
            Bind<ILogger>().To<NLogger>();
        }
    }
}
