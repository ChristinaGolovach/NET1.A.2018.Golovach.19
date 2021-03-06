﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Configuration;
using XMLGeneratorLogic.DataProvider;
using XMLGeneratorLogic.Mapper;
using XMLGeneratorLogic.Parser;
using XMLGeneratorLogic.Logger;
using XMLGeneratorLogic.Validator;
using XMLGeneratorLogic.Validator.UriValidators;
using XMLGeneratorLogic.XMLGenerator;
using XMLGeneratorLogic.Storage;
using Ninject.Modules;

namespace DependencyResolving
{
    public class Bindings : NinjectModule
    {       

        public override void Load()
        {
            string dataProviderPath = ConfigurationManager.AppSettings["dataProviderPath"];
            string storagePath = ConfigurationManager.AppSettings["storagePath"];

            Bind<IDataProvider<ICollection<string>>>().To<UriInStringFormatDataProvider>().WithConstructorArgument("filePath", dataProviderPath);
            Bind<IStorage<ICollection<Uri>>>().To<XMLFileStorage>().WithConstructorArgument("path", storagePath);
            Bind<IXMLGenerator<ICollection<Uri>, XElement>>().To<XMLGeneratorForURISchemeHostPathParameters>();
            Bind<IMapper<string, Uri>>().To<UriMapper>();
            Bind<IParser<string, Uri>>().To<StringToUriParser>();
            Bind<IValidator<Uri>>().To<UriHostNameValidator>();
            Bind<ILogger>().To<NLogger>();
        }
    }
}
