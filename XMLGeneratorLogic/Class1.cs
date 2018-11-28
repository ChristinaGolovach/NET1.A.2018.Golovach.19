using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMLGeneratorLogic.DataProvider;
using XMLGeneratorLogic.Mapper;
using XMLGeneratorLogic.XMLGenerator;

namespace XMLGeneratorLogic
{
    public class Processor
    {
        private IXMLGenerator<ICollection<Uri>, XElement> XMLGenerator;
        private IDataProvider<ICollection<string>> dataProvider;
        private IMapper<string, Uri> mapper;

        private ICollection<string> uriesInStringFormat;
        private ICollection<Uri> uries;

        public Processor(IDataProvider<ICollection<string>> dataProvider, IMapper<string, Uri> mapper, IXMLGenerator<ICollection<Uri>, XElement> XMLGenerator)
        {
            this.dataProvider = dataProvider;
            this.mapper = mapper;
            this.XMLGenerator = XMLGenerator;
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

            xElement.Save("test.xml");
        }
    }
}
