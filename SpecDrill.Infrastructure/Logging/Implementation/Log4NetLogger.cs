using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using SpecDrill.Infrastructure.Logging.Interfaces;

namespace SpecDrill.Infrastructure.Logging.Implementation
{
    class Log4NetLogger : ILogger
    {
        private readonly ILog logger;

        public Log4NetLogger(ILog logger)
        {
            this.logger = logger;
        }

        public void Log(LogLevel level, object message)
        {
            CallLogger(level, message);
        }

        public void Log(LogLevel level, string format, params object[] args)
        {
            CallLogger(level, string.Format(format, args));
        }

        public void Log(LogLevel level, Exception exception, object message)
        {
            CallLogger(level, message, exception);
        }

        public void Log(LogLevel level, Exception exception, string format, params object[] args)
        {
            CallLogger(level, string.Format(format, args), exception);
        }

        private void CallLogger(LogLevel level, object message, Exception exception = null)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    if (logger.IsDebugEnabled)
                    {
                        logger.Debug(message, exception);
                    }
                    return;
                case LogLevel.Error:
                    if (logger.IsErrorEnabled)
                    {
                        logger.Error(message, exception);
                    }
                    return;
                case LogLevel.Fatal:
                    if (logger.IsFatalEnabled)
                    {
                        logger.Fatal(message, exception);
                    }
                    return;
                case LogLevel.Info:
                    if (logger.IsInfoEnabled)
                    {
                        logger.Info(message, exception);
                    }
                    return;
                default:
                    if (logger.IsWarnEnabled)
                    {
                        logger.Warn(message, exception);
                    }
                    return;
            }
        }
    }
}
