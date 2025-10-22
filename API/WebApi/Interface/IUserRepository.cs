using WebApi.Models;

namespace WebApi.Interface
{
    public interface IUserRepository
    {
        Task<User> FindByUsernameAsync(string username);
        Task<User> FindByIdAsync(string id);
        Task AddUserAsync(User user);
        Task<bool> ValidatePasswordAsync(User user, string password);
    }
}
