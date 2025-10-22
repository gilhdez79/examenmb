using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class User 
    {
        [Key]
        public string Id { get; set; } // O int, si tu clave es de tipo entero
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
