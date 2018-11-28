using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XMLGeneratorLogic.DataProvider
{
    public class UriInStringFormatDataProvider : IDataProvider<ICollection<string>>
    {
        private ICollection<string> uriStrings;
        private string filePath;

        //TODO check
        public UriInStringFormatDataProvider(string filePath)
        {
            uriStrings = new List<string>();
            this.filePath = filePath;
        }

        //TODO подумать, может лучше счітывать і сразу проверять валідная лі строка
        public ICollection<string> Provide()
        {
            ReadFile(filePath);

            return uriStrings;
        }

        private void ReadFile(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException($"The {nameof(filePath)} can not be null.");
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"Incorrect {nameof(filePath)}.");
            }

            using (TextReader textReader = new StreamReader(File.OpenRead(filePath)))
            {
                while(textReader.Peek() > -1)
                {
                    uriStrings.Add(textReader.ReadLine());
                }
            }
                        
        }
    }
}
