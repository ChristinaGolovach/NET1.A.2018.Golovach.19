using System;
using System.Collections.Generic;
using System.Xml.Linq;
using XMLGeneratorLogic.DataProvider;
using XMLGeneratorLogic.Mapper;
using XMLGeneratorLogic.XMLGenerator;
using XMLGeneratorLogic.Storage;


namespace XMLGeneratorLogic
{
    //TODO make generic
    public class Processor
    {
        private IXMLGenerator<ICollection<Uri>, XElement> XMLGenerator;
        private IDataProvider<ICollection<string>> dataProvider;
        private IMapper<string, Uri> mapper;
        private IStorage<XElement> storage;

        private ICollection<string> uriesInStringFormat;
        private ICollection<Uri> uries;

        public Processor(IDataProvider<ICollection<string>> dataProvider, IMapper<string, Uri> mapper, IXMLGenerator<ICollection<Uri>, XElement> XMLGenerator, IStorage<XElement> storage)
        {
            this.dataProvider = dataProvider;
            this.mapper = mapper;
            this.XMLGenerator = XMLGenerator;
            this.storage = storage;
            uries = new List<Uri>();
        }

        public void ConvertData()
        {
            uriesInStringFormat = dataProvider.Provide();

            foreach (string uriInString in uriesInStringFormat)
            {
                Uri uri = mapper.Map(uriInString);

                if (uri != null)
                {
                    uries.Add(uri);
                }
            }

            XElement xElement =  XMLGenerator.GenerateXML(uries);

            storage.Save(xElement);
        }
    }
}
