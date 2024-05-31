using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Infrastructure.Repositories;
using Wpf.Models;

namespace Wpf.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> AddUser(User model)
        {
            return await _userRepository.AddUser(model);
        }
    }
}
