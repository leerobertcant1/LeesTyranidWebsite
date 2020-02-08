using System;
using BusinessLogic.Abstractions;
using NLog;

namespace BusinessLogic.Services.Logger
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogError(Exception ex, string message) =>
            logger.Error(ex, message);
    }
}
