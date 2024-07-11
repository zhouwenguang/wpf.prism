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
        public Task<bool> AddUser(User model)
        {
            Console.WriteLine("{model}");
            return Task.FromResult(true);
        }

        public Task<User> GetUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
