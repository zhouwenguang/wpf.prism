using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Models;

namespace Wpf.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> GetUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
