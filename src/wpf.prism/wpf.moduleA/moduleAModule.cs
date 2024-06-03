using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using wpf.moduleA.Views;
using Wpf.Infrastructure.Repositories;
using Wpf.Prism.Core;
using Wpf.Services;

namespace wpf.moduleA
{
    public class moduleAModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public moduleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            //在初始化进行试图导航等操作
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "ViewA");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册服务和视图
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.Register<IUserRepository, UserRepository>();
            containerRegistry.Register<IUserService, UserService>();
        }
    }
}