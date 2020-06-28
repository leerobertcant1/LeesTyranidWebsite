﻿using System.Web.Http;
using DataManager.Abstractions;
using DataManager.Factories;
using DataManager.Unit_Of_Work.Query;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace DataManager
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            RegisterUnity();
        }

        private static void RegisterUnity()
        {
            var container = new UnityContainer();

            container.RegisterType<IQueryUnitOfWork, QueryUnitOfWork>();
            container.RegisterType<IRepositoryFactory, RepositoryFactory>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}