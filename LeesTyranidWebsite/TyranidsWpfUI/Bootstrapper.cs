using System.Windows;
using Caliburn.Micro;
using TyranidsWpfUI.ViewModels;

namespace TyranidsWpfUI
{
    class Bootstrapper: BootstrapperBase
    {
        public Bootstrapper() =>
            Initialize();
        
        protected override void OnStartup(object sender, StartupEventArgs e) =>
            DisplayRootViewFor<ShellViewModel>();
        
    }
}
