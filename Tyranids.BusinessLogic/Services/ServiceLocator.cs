using System;
using System.Collections.Generic;
using Tyranids.BusinessLogic.Abstractions;
using Tyranids.Globals;

namespace Tyranids.BusinessLogic.Services
{
    public class ServiceLocator : IServiceLocator
    {
        public T Get<T>()
        {
            try
            {
                var services = GetServices();

                return (T)services[typeof(T)];
            }
            catch (Exception ex)
            {
                new SeriLoggerService().LogData(ex);

                throw new NotImplementedException(GlobalStrings.ErrorOccurred);
            }
        }

        private Dictionary<object, object> GetServices()
        {
            return new Dictionary<object, object> 
            {
                { typeof(IApiDataService), new ApiDataService(new ServiceLocator()) },
                { typeof(IApiService), new ApiService() },
                { typeof(IJsonService), new JsonService() },
                { typeof(ISeriLoggerService), new SeriLoggerService() }
            };
        }
    }
}
