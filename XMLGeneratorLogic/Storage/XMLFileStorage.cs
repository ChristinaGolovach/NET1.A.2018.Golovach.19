using System;
using System.Collections.Generic;
using System.Xml.Linq;
using XMLGeneratorLogic.XMLGenerator;

namespace XMLGeneratorLogic.Storage
{
    public class XMLFileStorage : IStorage<ICollection<Uri>>
    {
        private string path;
        private IXMLGenerator<ICollection<Uri>, XElement> XMLGenerator;

        public XMLFileStorage(string path, IXMLGenerator<ICollection<Uri>, XElement> XMLGenerator)
        {
            this.path = path;
            this.XMLGenerator = XMLGenerator;
        }

        public void Save(ICollection<Uri> dataForStore)
        {
            XElement xElement = XMLGenerator.GenerateXML(dataForStore);
            xElement.Save(path);
        }
    }
}
