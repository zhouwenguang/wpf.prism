
using Wpf.Models;

namespace Wpf.Services
{
    public interface IUserService
    {
        Task<bool> AddUser(User model);
    }

}
