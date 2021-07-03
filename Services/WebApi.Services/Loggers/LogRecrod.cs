using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Interfaces;

namespace WebApi.Services.Loggers
{
    public class LogRecord
    {

        /// <summary>
        /// The application responsible for the log.
        /// AJ.
        /// </summary>
        public string Application { get; set; }

        /// <summary>
        /// The record date.
        /// AJ.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The record level.
        /// AJ.
        /// </summary>
        public LogLevel Level { get; set; }

        /// <summary>
        /// The record source
        /// AJ.
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// The content of the log record
        /// AJ.
        /// </summary>
        public string Content { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var eventInfoBuilder = new StringBuilder();
            eventInfoBuilder.Append($">[{Date}]");
            eventInfoBuilder.Append($"  [{Application}]");
            eventInfoBuilder.Append($"  [{Level}]");
            eventInfoBuilder.Append($"  [{Source}]");
            eventInfoBuilder.Append($"  {Content}");
            return eventInfoBuilder.ToString();
        }
    }
}
