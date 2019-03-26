using System;

namespace BusinessLogic.Abstractions
{
    public interface ILoggerService
    {
        void LogError(Exception ex, string message);
    }
}
