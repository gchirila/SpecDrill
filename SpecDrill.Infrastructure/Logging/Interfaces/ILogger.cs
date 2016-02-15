using System;

namespace SpecDrill.Infrastructure.Logging.Interfaces
{
    public enum LogLevel
    {
        Info, Warning, Debug, Error, Fatal
    }

    public interface ILogger
    {
        void Log(LogLevel level, object message);
        void Log(LogLevel level, string format, params object[] args);
        void Log(LogLevel level, Exception exception, object message);
        void Log(LogLevel level, Exception exception, string format, params object[] args);
    }
}
