using Prism.Ioc;
using Prism.Modularity;
using System.Configuration;
using System.Data;
using System.Windows;
using Wpf.Infrastructure.Repositories;
using wpf.prism.ViewModels;
using wpf.prism.Views;
using Wpf.Services;
using DryIoc;
using Prism.DryIoc;

namespace wpf.prism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册服务和视图
            containerRegistry.Register<LoginViewModel>();
            containerRegistry.RegisterForNavigation<LoginView>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //配置模块
            moduleCatalog.AddModule<wpf.moduleA.moduleAModule>();
        }
    }

}
