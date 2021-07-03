using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Interfaces;

namespace WebApi.Services.Loggers
{
    public class InMemoryLogger : LoggerBase
    {
        public static string Key = "InMemory";
        public InMemoryLogger(string applicationName, bool includeDebugInfo)
            : base(applicationName, includeDebugInfo)
        {
            LogList = new List<LogRecord>();
        }

        protected List<LogRecord> LogList { get; private set; }

        public override void Log(string source, string message, LogLevel logLevel = LogLevel.Information)
        {
            LogList.Add(new LogRecord
            {
                Content = message,
                Source = source,
                Application = _application,
                Level = logLevel,
                Date = DateTime.Now
            });
        }

        public IReadOnlyList<LogRecord> GetRecords()
        {
            return LogList.AsReadOnly();
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    LogList.Clear();
                    LogList = null;
                }


                disposedValue = true;
            }
        }


        // This code added to correctly implement the disposable pattern.
        public override void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
    }
}
