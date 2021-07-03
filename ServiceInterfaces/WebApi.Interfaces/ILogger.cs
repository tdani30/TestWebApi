using System;

namespace WebApi.Interfaces
{
    [Flags]
    public enum LogLevel
    {
        Debug = 1 << 1,
        Information = 1 << 2,
        Warning = 1 << 3,
        Error = 1 << 4
    }

    public interface ILogger : IDisposable
    {
        void Log(string source, string message, LogLevel logLevel = LogLevel.Information);
        void Log(string source, Exception exception, LogLevel logLevel = LogLevel.Error);
    }
}
