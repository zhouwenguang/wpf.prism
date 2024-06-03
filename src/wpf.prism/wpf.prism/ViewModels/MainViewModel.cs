using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf.prism.Views;
using Wpf.Prism.Core;

namespace wpf.prism.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public RelayCommand ClickCommand { get; set; }
        public MainViewModel(IContainerExtension container, IRegionManager regionManager)
        {
            //var view = container.Resolve<LoginView>();
            ////IRegion region = regionManager.Regions[RegionNames.ContentRegion];
            ////region.Add(view);
            //regionManager.RequestNavigate(RegionNames.ContentRegion, "LoginView");
            ////ClickCommand = new RelayCommand(() =>
            ////{
            ////    regionManager.RequestNavigate(RegionNames.ContentRegion, "LoginView");
            ////});

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
