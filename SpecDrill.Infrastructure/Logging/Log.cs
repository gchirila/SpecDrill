using System;
using SpecDrill.Infrastructure.Logging.Implementation;
using SpecDrill.Infrastructure.Logging.Interfaces;
using ILoggerFactory = SpecDrill.Infrastructure.Logging.Interfaces.ILoggerFactory;

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
            return loggerFactory.Get(name);
        }

        public static ILogger Get<T>()
        {
            return loggerFactory.Get(typeof(T).Namespace);
        }

        public static ILogger Get(Type type)
        {
            return loggerFactory.Get(type.Namespace);
        }
    }
}
