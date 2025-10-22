using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using WebApi.Data;
using WebApi.Interface;
using WebApi.Models;

namespace WebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> FindByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> FindByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public Task<bool> ValidatePasswordAsync(User user, string password)
        {
            // Usa la biblioteca BCrypt para comparar el hash
            return Task.FromResult(BCrypt.Net.BCrypt.Verify(password, user.PasswordHash));
        }

    }
}
