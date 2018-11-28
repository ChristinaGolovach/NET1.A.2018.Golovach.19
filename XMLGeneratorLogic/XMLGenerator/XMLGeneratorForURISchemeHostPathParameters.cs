using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XMLGeneratorLogic.XMLGenerator
{
    public class XMLGeneratorForURISchemeHostPathParameters : IXMLGenerator<ICollection<Uri>, XElement>
    {
        public XElement GenerateXML(ICollection<Uri> uries)
        {
            if (uries == null)
            {
                throw new ArgumentNullException($"The {nameof(uries)} can not be null.");
            }

            XElement xElement = new XElement("urlAddresses",
                    uries.Select(u =>
                        new XElement("urlAddress",
                            new XElement("host", new XAttribute("name", u.Host),
                                new XElement("uri",
                                    u.Segments.Select(s => s.Trim('/') == "" ? null :
                                    u.Segments?.Select(sNew => new XElement("segment", sNew.Trim('/')))),
                                    u.Query == "" ? null :
                                    new XElement("parameters",
                                        new XElement("parametr", new XAttribute("value", u.Query))))))));

            return xElement;
        }
    }
}
