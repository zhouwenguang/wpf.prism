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
using Microsoft.Extensions.Logging;
using NLog;
using Microsoft.Extensions.DependencyInjection;
using Wpf.Common;
using System;
using ILogger = Microsoft.Extensions.Logging.ILogger;

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
            var services = new ServiceCollection();
            var serviceProvider = services.ConfigureServices();
            containerRegistry.RegisterInstance(serviceProvider.GetService<ILoggerFactory>());
            containerRegistry.Register(typeof(ILogger<>), typeof(Logger<>));


            //Logger
            //var factory = new NLog.Extensions.Logging.NLogLoggerFactory();
            //var logger = factory.CreateLogger("");
            //containerRegistry.RegisterInstance<Microsoft.Extensions.Logging.ILogger>(logger);

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
