using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Prism.Core.Mvvm;
using Wpf.Services;

namespace wpf.prism.ViewModels
{
    public class LoginViewModel : RegionViewModelBase
    {
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }

        private readonly IRegionManager _regionManager;
        private IUserService _userService;
        private ILogger<LoginViewModel> _logger;
        public LoginViewModel(IRegionManager regionManager, IUserService userService, ILogger<LoginViewModel> logger) : base(regionManager)
        {
            LoginCommand = new RelayCommand(Login);
            ResetCommand = new RelayCommand(() =>
            {
                UserName = string.Empty;
                Password = string.Empty;
            });
            this._regionManager = regionManager;
            _userService = userService;
            _logger = logger;

            _logger.LogInformation("进入LoginViewModel");
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            try
            {
                int a = 3;
                int b = 0;
                var r = a / b;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "自己制造异常");
            }
            //do something
            _logger.LogInformation("OnNavigatedTo");
        }

        private void Login()
        {
            Password = "123456";
            _userService.AddUser(new Wpf.Models.User { UserName = UserName, Password = Password });
        }

        private string _userName;
        private string _password;
        public string UserName
        {
            get => _userName; set => SetProperty(ref _userName, value);
        }

        public string Password
        {
            get => _password; set => SetProperty(ref _password, value);
        }

    }
}
