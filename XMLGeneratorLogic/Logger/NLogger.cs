using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace XMLGeneratorLogic.Logger
{
    public class NLogger : ILogger
    {
        private NLog.Logger logger; 

        public NLogger()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        public void Log(string info)
        {
            logger.Info(info);
        }
    }
}
