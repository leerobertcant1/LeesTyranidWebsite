using Serilog;
using System;
using System.IO;
using Tyranids.BusinessLogic.Abstractions;

namespace Tyranids.BusinessLogic.Services
{
    public class SeriLoggerService : ISeriLoggerService
    {
        public void LogData(Exception ex)
        {
            var log = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .WriteTo.File(Path.Combine(Environment.CurrentDirectory, @"log\log.txt"))
             .CreateLogger();

            log.Information(ex.Message);
        }
    }
}
