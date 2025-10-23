using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Interface;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectoController : ControllerBase
    {
        private readonly IProyectoRepository _proyectoRepository;
        public ProyectoController(IProyectoRepository proyectoRepository)
        {
            _proyectoRepository = proyectoRepository;
        }
        [HttpGet]
        [Route("GetUserProyectos/{userId}")]
        public async Task<IActionResult> GetUserProyectos(string userId)
        {
            try
            {
                var user_Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var Proyectos = await _proyectoRepository.GetProyectosByUserIdAsync(userId);
                return Ok(Proyectos);
            }
            catch (Exception ex)
            {
                return NoContent();
            }


        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProyecto(int id)
        {
            var Proyecto = await _proyectoRepository.GetProyectosByIdAsync(id);
            if (Proyecto == null)
            {
                return NotFound();
            }
            return Ok(Proyecto);
        }

        [HttpPost]
        public async Task<IActionResult> AddProyecto([FromBody] Proyecto Proyecto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Proyecto.UserName = userId;
            await _proyectoRepository.AddProyectoAsync(Proyecto);
            return CreatedAtAction(nameof(GetProyecto), new { id = Proyecto.Id }, Proyecto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProyecto(int id, [FromBody] Proyecto Proyecto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var existingProyecto = await _proyectoRepository.GetProyectosByIdAsync(id);

            if (existingProyecto == null || existingProyecto.UserName != userId)
            {
                return NotFound();
            }

            existingProyecto.Name = Proyecto.Name;
            existingProyecto.Description = Proyecto.Description;

            await _proyectoRepository.UpdateProyectoAsync(existingProyecto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyecto(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var proyecto = await _proyectoRepository.GetProyectosByIdAsync(id);
            if (proyecto == null || proyecto.UserName != userId)
            {
                return NotFound();
            }

            await _proyectoRepository.DeleteProyectoAsync(id);
            return NoContent();
        }
    }
}
