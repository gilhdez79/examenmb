using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

using WebApi.Dtos;
using WebApi.Interface;
using WebApi.Models;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private IUserRepository _userRepository;


        public AuthenticationController(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login_Request login)
        {
            // In a real application, you would validate credentials against a database
            // or other user store. This is a simplified example.
            var validauser = await _userRepository.ValidateUserAsync(login);
            if (validauser)
            {
                var token = GenerateJwtToken(login.Username);
                return Ok(new { token });
            }

            return Unauthorized();
        }
        private string GenerateJwtToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), // Token expires in 30 minutes
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var userExists = await _userRepository.FindByUsernameAsync(model.Username);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, new { Status = "Error", Message = "El usuario ya existe!" });
            }

            User user = new()
            {
                Email = model.Email,
                PasswordHash = EncryptPassword(model.Password),
                Username = model.Username
            };

            var result = await _userRepository.AddUserAsync(user);
            if (!result)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Creación de usuario fallida." });
            }

            return Ok(new { Status = "Success", Message = "Usuario creado exitosamente!" });
        }
        private string EncryptPassword(string password)
        {

          return  BCrypt.Net.BCrypt.HashPassword(password);
        }
    }



}


