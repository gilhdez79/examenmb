using WebApi.Models;

namespace WebApi.Interface
{
    public interface ITareaRepository
    {
        Task<IEnumerable<Tarea>> GetTasksByProyectoIdAsync(int proyectoId);
        Task<Tarea> GetTareaByIdAsync(int taskId);
        Task AddTareaAsync(Tarea task);
        Task UpdateTareaAsync(Tarea task);
        Task DeleteTareaAsync(int taskId);
    }
}
