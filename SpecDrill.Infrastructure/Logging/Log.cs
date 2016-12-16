using System;
using SpecDrill.Infrastructure.Logging.Implementation;
using SpecDrill.Infrastructure.Logging.Interfaces;
using ILoggerFactory = SpecDrill.Infrastructure.Logging.Interfaces.ILoggerFactory;
using System.Diagnostics;

namespace SpecDrill.Infrastructure.Logging
{
    public static class Log
    {
        private static readonly ILoggerFactory loggerFactory;

        static  Log()
        {
            loggerFactory = new Log4NetFactory();
        }

        public static ILogger Get(string name)
        {
            return GetLogger(loggerFactory.Get(name));
        }

        public static ILogger Get<T>()
        {
            return GetLogger(loggerFactory.Get(typeof(T).Namespace));
        }

        public static ILogger Get(Type type)
        {
            return GetLogger(loggerFactory.Get(type.Namespace));
        }
        private static ILogger GetLogger(ILogger logger)
        {
            if (logger == null)
                Trace.Write($"Logger is null!");
            return logger;
        }

    }
}
