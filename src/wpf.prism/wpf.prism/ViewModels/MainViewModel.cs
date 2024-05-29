using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf.prism.Views;

namespace wpf.prism.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Body = new LoginView();
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
