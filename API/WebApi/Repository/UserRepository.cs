using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using WebApi.Data;
using WebApi.Interface;
using WebApi.Models;
using System.Reflection;

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
        public async Task<bool> ValidateUserAsync(Login_Request loginRequest )
        {

            var _user = await _context.Users.FirstOrDefaultAsync(u=> u.Username == loginRequest.Username);
            if (_user != null) {

                var validapass = await ValidatePasswordAsync(_user, loginRequest.Password);
                if (validapass) {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            _context.Users.Add(user);
         var res =   await _context.SaveChangesAsync();

            if (res>0)
            {
                return true;
            }
            return false;
        }

        public Task<bool> ValidatePasswordAsync(User user, string password)
        {
            // Usa la biblioteca BCrypt para comparar el hash
            return Task.FromResult(BCrypt.Net.BCrypt.Verify(password, user.PasswordHash));
        }

    }
}
