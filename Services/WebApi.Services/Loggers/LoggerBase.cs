using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Interfaces;

namespace WebApi.Services.Loggers
{
    /// <summary>
    /// A base class for <see cref="ILogger"/> implementation.
    /// AJ.
    /// </summary>
    public abstract class LoggerBase : ILogger
    {
        protected LoggerBase(string application, bool includeDebugInfo)
        {
            _application = application;
            _includeDebugInfo = includeDebugInfo;
        }

        protected readonly string _application;
        protected readonly bool _includeDebugInfo;

        public abstract void Log(string source, string message, LogLevel logLevel = LogLevel.Information);

        public virtual void Log(string source, Exception exception, LogLevel logLevel = LogLevel.Information)
        {
            Log(source, BuildExceptionString(exception), logLevel);
        }


        /// <summary>
        /// Build a string that represent the exception object
        /// AJ.
        /// </summary>
        /// <param name="exception">The exception object</param>
        /// <param name="level">The exception depth for spacing inner exception</param>
        protected string BuildExceptionString(Exception exception, int level = 0)
        {
            var execptionInfoBuilder = new StringBuilder();
            var append = "";
            if (level != 0)
                for (int i = 0; i < level + 1; i++)
                {
                    append += "  ";
                }
            execptionInfoBuilder.Append($"\n{append}  Exception Type : {exception.GetType().Name}");
            execptionInfoBuilder.Append($"\n{append}  Details: {exception.Message}");
            if (_includeDebugInfo)
            {
                execptionInfoBuilder.Append($"\n{append}  Source: {exception.Source}");
                execptionInfoBuilder.Append($"\n{append}  Trace: {exception.StackTrace}");
            }

            if (exception.InnerException != null)
            {
                execptionInfoBuilder.Append("\n");
                execptionInfoBuilder.Append(BuildExceptionString(exception.InnerException, level + 1));
            }
            return execptionInfoBuilder.ToString();
        }

        public abstract void Dispose();
    }
}
