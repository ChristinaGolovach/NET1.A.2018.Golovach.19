using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneratorLogic.Parser
{
    public class StringToUriParser : IParser<string, Uri>
    {
        //TODO Check
        public Uri Parse(string value)
        {           
            Uri uri;

            if (Uri.TryCreate(value, UriKind.Absolute, out uri))
            {
                return uri;
            }

            return null;
        }
    }
}
