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
        Task<bool> AddUser(User model);
        Task<User> GetUserByUserName(string userName);
    }
}
