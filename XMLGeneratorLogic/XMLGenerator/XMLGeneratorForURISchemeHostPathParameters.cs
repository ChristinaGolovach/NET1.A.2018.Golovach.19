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
                                    u.Segments.Select(sNew => new XElement("segment", sNew.Trim('/')))),
                                    u.Query == "" ? null :
                                    new XElement("parameters",
                                        ParseQuery(u.Query).Select(query => new XElement("parametr", new XAttribute("value", query.Value), new XAttribute("key", query.Key))))))));

            return xElement;
        }

        private Dictionary<string, string> ParseQuery(string query)
        {
            Dictionary<string, string> queryParameters = new Dictionary<string, string>();

            string[] queries = query.Split('&');

            foreach(string separateQuery in queries)
            {
                string[] keyValue = separateQuery.Split('=');
                queryParameters.Add(keyValue[0].Trim('?'), keyValue[1]);
            }

            return queryParameters;
        }
    }
}
