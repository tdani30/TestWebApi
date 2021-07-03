using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Timers;
using WebApi.Interfaces;

namespace WebApi.Services.Loggers
{
    public class FileLogger : LoggerBase, IDisposable
    {
        public static string Key = "File";
        protected readonly string _filePath;
        protected FileInfo _file;
        protected Queue<LogRecord> _logBuffer;

        protected StreamWriter _fileStream;
        private bool _disposing;
        public FileLogger(string filePath, string applicationName, bool includeDebugInfo, double commitEvery = 500)
            : base(applicationName, includeDebugInfo)
        {

            _filePath = filePath;
            _file = new FileInfo(_filePath);
            _logBuffer = new Queue<LogRecord>();


            if (!_file.Exists)
                _file.Create().Dispose();
        }

        /// <summary>
        /// Write the log buffer to disk.
        /// AJ.
        /// </summary>
        private void CommitLog(object sender, ElapsedEventArgs e)
        {
            bool hasLog = false;

            while (!_disposing && _logBuffer.TryDequeue(out var log))
            {
                hasLog = true;
                if (_fileStream == null)
                {
                    var stream = _file.OpenWrite();
                    stream.Seek(0, SeekOrigin.End);
                    _fileStream = new StreamWriter(stream);
                }

                _fileStream.WriteLine(log.ToString());
            }

            if (hasLog && _fileStream != null)
            {
                _fileStream.Flush();
                _fileStream.Dispose();
                _fileStream = null;
            }
        }

        public override void Log(string source, string message, LogLevel logLevel = LogLevel.Information)
        {
            var log = new LogRecord
            {
                Content = message,
                Source = source,
                Level = logLevel,
                Application = _application,
                Date = DateTime.Now
            };
            _logBuffer.Enqueue(log);
        }

        /// <summary>
        /// To detect redundant calls
        /// </summary>
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            _disposing = disposing;
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_fileStream != null)
                    {
                        _fileStream.Flush();
                        _fileStream.Dispose();
                        _fileStream = null;
                    }

                    _logBuffer.Clear();
                    _logBuffer = null;
                    _file = null;
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
