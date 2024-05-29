using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf.prism.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            ResetCommand = new RelayCommand(() =>
            {
                UserName = string.Empty;
                Password = string.Empty;
            });
        }

        private void Login()
        {
            Password = "123456";
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
