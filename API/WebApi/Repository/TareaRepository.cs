using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interface;
using WebApi.Models;

namespace WebApi.Repository
{
    public class TareaRepository : ITareaRepository
    {
        private readonly DataContext _context;

        public TareaRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddTareaAsync(Tarea task)
        {
            _context.Tareas.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTareaAsync(int taskId)
        {
            var task = await _context.Tareas.FindAsync(taskId);
            if (task != null)
            {
                _context.Tareas.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Tarea> GetTareaByIdAsync(int taskId)
        {
            return await  _context.Tareas.FindAsync(taskId);
        }

        public async Task<IEnumerable<Tarea>> GetTasksByProyectoIdAsync(int proyectoId)
        {
            return await  _context.Tareas.Where(t => t.ProyectoId == proyectoId).ToListAsync();
        }

        public async Task UpdateTareaAsync(Tarea task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public   async Task<IEnumerable<TareaDash>> GetTasksByProyectoDashboardAsync(int userid)
        {


           var db = await  _context.Tareas.SelectMany(tr=>_context.Proyectos.Where(w=>w.Id == tr.ProyectoId).
                                      DefaultIfEmpty(), (t,p)=> new
                                      {
                                          t.Estado,
                                          t.Id,
                                          t.ProyectoId,
                                          p.Name

                                      }).GroupBy(g=> new { g.Id, g.Name })
                                      .Select(s=> new TareaDash
                                      {
                                          Id = s.Key.Id,
                                          NombreEstado= s.Key.Name,
                                          Total = s.Sum(_ => _.Estado),

                                      }).ToListAsync();
            return  db;

        }

        public async Task AssignTaskAsync(int taskId, string newUserId)
        {
            var task = await _context.Tareas.FindAsync(taskId);
            if (task != null)
            {
                task.UserId = newUserId;
                _context.Entry(task).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
