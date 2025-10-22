using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class TipoEstado
    {
        [Key]
        public int Id { get; set; }
        public string NombreEstado { get; set; }
    }
}
