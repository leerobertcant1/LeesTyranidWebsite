using System;

namespace Tyranids.BusinessLogic.Abstractions
{
    public interface ISeriLoggerService
    {
        void LogData(Exception ex);
    }
}
