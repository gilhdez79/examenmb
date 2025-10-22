using WebApi.Models;

namespace WebApi.Interface
{
    public interface ITareaRepository
    {
        Task<IEnumerable<Tarea>> GetTasksByProyectoIdAsync(int proyectoId);
        Task<IEnumerable<TareaDash>> GetTasksByProyectoDashboardAsync(int userid);
        Task<Tarea> GetTareaByIdAsync(int taskId);
        Task AddTareaAsync(Tarea task);
        Task UpdateTareaAsync(Tarea task);
        Task DeleteTareaAsync(int taskId);
        // Nuevo método para asignar tareas
        Task AssignTaskAsync(int tareaId, string newUserId);
    }
}
