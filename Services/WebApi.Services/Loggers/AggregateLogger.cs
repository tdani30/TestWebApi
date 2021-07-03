using System;
using System.Collections.Generic;
using WebApi.Interfaces;

namespace WebApi.Services.Loggers
{
    /// <summary>
    /// An <see cref="ILogger"/> implementation that combines multiple loggers.
    /// </summary>
    public class AggregateLogger : LoggerBase
    {
        public AggregateLogger(bool includeDebugInfo)
           : base(null, includeDebugInfo)
        {
            Loggers = new List<ILogger>();
        }

        public List<ILogger> Loggers { get; private set; }

        public void AddLogger(ILogger logger)
        {
            if (!Loggers.Contains(logger))
                Loggers.Add(logger);
        }

        public override void Log(string source, string message, LogLevel logLevel = LogLevel.Information)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(source, message, logLevel);
            }
        }


        /// <summary>
        /// To detect redundant calls
        /// </summary>
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach (var logger in Loggers)
                    {
                        logger.Dispose();
                    }
                    Loggers.Clear();
                    Loggers = null;
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
