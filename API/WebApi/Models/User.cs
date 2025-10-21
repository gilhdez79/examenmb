using Microsoft.AspNetCore.Identity;

namespace WebApi.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Proyecto> Projects { get; set; } = new List<Proyecto>();
    }
}
