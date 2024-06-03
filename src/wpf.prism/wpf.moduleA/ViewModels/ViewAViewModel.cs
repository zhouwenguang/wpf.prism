using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Infrastructure.Repositories;
using Wpf.Services;

namespace wpf.moduleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        public ViewAViewModel(IRegionManager regionManager, IUserService userService)
        {
            userService.AddUser(new Wpf.Models.User { Name = "aaa" });
            Message = "View A from your Prism Module";
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel()
        {
        }
    }
}
