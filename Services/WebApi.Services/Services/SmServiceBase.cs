
using SD.BuildingBlocks.Infrastructure;
using System;
using WebApi.Interfaces;

namespace WebApi.Services.Services
{
    public class SmServiceBase
    {
        private readonly string _logSource;

        protected readonly IUnitOfWork _unitofWork;
        protected readonly ILogger _logger;

        public SmServiceBase(IUnitOfWork unitofWork,
                              ILogger logger,
                              string logSource)
        {
            _logSource = logSource;
            _unitofWork = unitofWork;
            _logger = logger;
        }


        protected void Log(string message, LogLevel level = LogLevel.Information)
        {
            _logger.Log(_logSource, message, level);
        }

        protected void Log(Exception ex, LogLevel level = LogLevel.Error)
        {
            _logger.Log(_logSource, ex, level);
        }
       
    }
}
