using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf.moduleA.Events;
using wpf.prism.Views;
using Wpf.Prism.Core;

namespace wpf.prism.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public DelegateCommand ClickCommand { get; set; }
        public readonly IEventAggregator _eventAggregator;
        public readonly IRegionManager _regionManager;
        public MainViewModel(IContainerExtension container, IRegionManager regionManager, IEventAggregator eventAggregator)
         {
            //var view = container.Resolve<LoginView>();
            ////IRegion region = regionManager.Regions[RegionNames.ContentRegion];
            ////region.Add(view);
            //regionManager.RequestNavigate(RegionNames.ContentRegion, "LoginView");
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            ClickCommand = new DelegateCommand(Click);
        }

        public void Click()
        {
            _eventAggregator.GetEvent<MyCustomEvent>().Publish("我MainViewModel发布了一个Click消息");
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "LoginView");
        }

        private object body;

        public object Body
        {
            get { return body; }
            set { body = value; }
        }

        private string title = "无敌操作";

        public string Title
        {
            get { return title; }
            set { title = value; }
        }


    }
}
