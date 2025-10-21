using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interface;
using WebApi.Models;

namespace WebApi.Repository
{
    public class ProyectoRepository: IProyectoRepository
    {
        private readonly DataContext _context;

        public ProyectoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proyecto>> GetProyectosByUserIdAsync(string userId)
        {
            return await _context.Proyectos.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<Proyecto> GetProyectosByIdAsync(int projectId)
        {
            return await _context.Proyectos.FindAsync(projectId);
        }

        public async Task AddProjectAsync(Proyecto project)
        {
            _context.Proyectos.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Proyecto project)
        {
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            var project = await _context.Proyectos.FindAsync(projectId);
            if (project != null)
            {
                _context.Proyectos.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
 
    }
}
