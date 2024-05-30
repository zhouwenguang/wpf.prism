using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Models;

namespace Wpf.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserName(string userName);
    }
}
