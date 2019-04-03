using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using DataManager.Abstractions;
using DataManager.Factories;
using DataManager.Unit_Of_Work.Query;
using TyranidsApi.Abstractions;
using TyranidsApi.Services;
using TyranidsWpfUI.ViewModels;

namespace TyranidsWpfUI
{
    class Bootstrapper: BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper() =>
            Initialize();

        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IQueryUnitOfWork, QueryUnitOfWork>()
                .Singleton<IRepositoryFactory, RepositoryFactory>()
                .Singleton<IApiService, ApiService>();
                               
            GetContainerTypes();
        }

        protected override void OnStartup(object sender, StartupEventArgs e) =>
            DisplayRootViewFor<ShellViewModel>();

        protected override object GetInstance(Type service, string key) =>
             _container.GetInstance(service, key);

        protected override IEnumerable<object> GetAllInstances(Type service) =>
             _container.GetAllInstances(service);

        protected override void BuildUp(object instance) =>
            _container.BuildUp(instance);

        private void GetContainerTypes()
        {
            GetType().Assembly.GetTypes()
               .Where(t => t.IsClass)
               .Where(t => t.Name.EndsWith("ViewModel"))
               .ToList()
               .ForEach(vmt => _container.RegisterPerRequest(
                   vmt, vmt.ToString(), vmt));
        }
    }
}
