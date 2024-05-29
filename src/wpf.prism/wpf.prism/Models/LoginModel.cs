using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf.prism.Models
{
    public class LoginModel : ObservableObject
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
