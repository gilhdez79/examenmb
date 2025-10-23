using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Proyecto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }

    }
}
