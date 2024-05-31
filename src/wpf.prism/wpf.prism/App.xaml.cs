﻿using Prism.Ioc;
using Prism.Modularity;
using System.Configuration;
using System.Data;
using System.Windows;
using wpf.prism.Code;
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
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册服务和视图
            containerRegistry.Register<MainViewModel>();
            containerRegistry.RegisterForNavigation<MainWindow, MainViewModel>();
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
