using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLGeneratorLogic.Storage
{
    public class XMLFileStorage : IStorage<XElement>
    {
        private string path;

        public XMLFileStorage(string path)
        {
            this.path = path;
        }

        public void Save(XElement dataForStore)
        {
            dataForStore.Save(path);
        }
    }
}
