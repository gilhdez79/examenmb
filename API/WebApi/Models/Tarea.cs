using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Tarea
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int ProyectoId { get; set; }
        public string UserId { get; set; }
        public string Estado { get; set; }
    }
}
