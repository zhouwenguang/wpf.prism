using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpf.prism.ViewModels;
using wpf.prism.Views;
using Wpf.Infrastructure.Repositories;
using Wpf.Services;

namespace wpf.prism.Code
{
    public class Bootstrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册服务和视图
            containerRegistry.Register<MainViewModel>();
            containerRegistry.Register<MainView>();
            containerRegistry.Register<LoginViewModel>();
            containerRegistry.Register<LoginView>();
            containerRegistry.Register<UserRepository>();
            containerRegistry.Register<UserService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //base.ConfigureModuleCatalog(moduleCatalog);
            //配置模块
            moduleCatalog.AddModule<wpf.moduleA.moduleAModule>();
        }

    }
}
