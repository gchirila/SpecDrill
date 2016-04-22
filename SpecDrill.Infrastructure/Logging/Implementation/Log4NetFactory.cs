using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using SpecDrill.Infrastructure.Logging.Interfaces;

namespace SpecDrill.Infrastructure.Logging.Implementation
{
    internal class Log4NetFactory : ILoggerFactory
    {
        private static ILogger logger = null;

        public ILogger Get(string name)
        {
            if (logger == null)
            {
                //XmlConfigurator.Configure();
                var log4NetLogger = LogManager.GetLogger(name);
                logger = new Log4NetLogger(log4NetLogger);
            }

            return logger;
        }
    }
}
