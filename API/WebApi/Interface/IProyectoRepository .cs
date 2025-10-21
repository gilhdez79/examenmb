using WebApi.Models;

namespace WebApi.Interface
{
    public interface IProyectoRepository
    {
        Task<IEnumerable<Proyecto>> GetProyectosByUserIdAsync(string userId);
        Task<Proyecto> GetProyectosByIdAsync(int projectId);
        Task AddProjectAsync(Proyecto project);
        Task UpdateProjectAsync(Proyecto project);
        Task DeleteProjectAsync(int projectId);
    }
}
