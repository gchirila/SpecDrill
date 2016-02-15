using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecDrill.Infrastructure.Logging.Interfaces;

namespace SpecDrill.Infrastructure.Logging
{
    public static class LoggerExtensions
    {
        public static void Info(this ILogger logger, object message)
        {
            logger.Log(LogLevel.Info, message);
        }
        public static void Info(this ILogger logger, string format, params object[] args)
        {
            logger.Log(LogLevel.Info, format, args);
        }
        public static void Info(this ILogger logger, Exception exception, object message)
        {
            logger.Log(LogLevel.Info, exception, message);
        }
        public static void Info(this ILogger logger, Exception exception, string format, params object[] args)
        {
            logger.Log(LogLevel.Info, exception, format, args);
        }

        public static void Warning(this ILogger logger, object message)
        {
            logger.Log(LogLevel.Warning, message);
        }
        public static void Warning(this ILogger logger, string format, params object[] args)
        {
            logger.Log(LogLevel.Warning, format, args);
        }
        public static void Warning(this ILogger logger, Exception exception, object message)
        {
            logger.Log(LogLevel.Warning, exception, message);
        }
        public static void Warning(this ILogger logger, Exception exception, string format, params object[] args)
        {
            logger.Log(LogLevel.Warning, exception, format, args);
        }

        public static void Debug(this ILogger logger, object message)
        {
            logger.Log(LogLevel.Debug, message);
        }
        public static void Debug(this ILogger logger, string format, params object[] args)
        {
            logger.Log(LogLevel.Debug, format, args);
        }
        public static void Debug(this ILogger logger, Exception exception, object message)
        {
            logger.Log(LogLevel.Debug, exception, message);
        }
        public static void Debug(this ILogger logger, Exception exception, string format, params object[] args)
        {
            logger.Log(LogLevel.Debug, exception, format, args);
        }

        public static void Error(this ILogger logger, object message)
        {
            logger.Log(LogLevel.Error, message);
        }
        public static void Error(this ILogger logger, string format, params object[] args)
        {
            logger.Log(LogLevel.Error, format, args);
        }
        public static void Error(this ILogger logger, Exception exception, object message)
        {
            logger.Log(LogLevel.Error, exception, message);
        }
        public static void Error(this ILogger logger, Exception exception, string format, params object[] args)
        {
            logger.Log(LogLevel.Error, exception, format, args);
        }

        public static void Fatal(this ILogger logger, object message)
        {
            logger.Log(LogLevel.Fatal, message);
        }
        public static void Fatal(this ILogger logger, string format, params object[] args)
        {
            logger.Log(LogLevel.Fatal, format, args);
        }
        public static void Fatal(this ILogger logger, Exception exception, object message)
        {
            logger.Log(LogLevel.Fatal, exception, message);
        }
        public static void Fatal(this ILogger logger, Exception exception, string format, params object[] args)
        {
            logger.Log(LogLevel.Fatal, exception, format, args);
        }
    }
}
