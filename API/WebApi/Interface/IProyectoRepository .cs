using WebApi.Models;

namespace WebApi.Interface
{
    public interface IProyectoRepository
    {
        Task<IEnumerable<Proyecto>> GetProyectosByUserIdAsync(string userId);
        Task<Proyecto> GetProyectosByIdAsync(int proyectoId);
        Task AddProyectoAsync(Proyecto proyecto);
        Task UpdateProyectoAsync(Proyecto proyecto);
        Task DeleteProyectoAsync(int proyectoId);
    }
}
