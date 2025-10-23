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
            return await _context.Proyectos.Where(p => p.UserName == userId).ToListAsync();
        }

        public async Task<Proyecto> GetProyectosByIdAsync(int proyectoId)
        {
            return await _context.Proyectos.FindAsync(proyectoId);
        }

        public async Task AddProyectoAsync(Proyecto proyecto)
        {
            _context.Proyectos.Add(proyecto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProyectoAsync(Proyecto proyecto)
        {
            _context.Entry(proyecto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProyectoAsync(int proyectoId)
        {
            var proyecto = await _context.Proyectos.FindAsync(proyectoId);
            if (proyecto != null)
            {
                _context.Proyectos.Remove(proyecto);
                await _context.SaveChangesAsync();
            }
        }

    }
}
