using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Interface;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/projects/{projectId}/[controller]")]
    public class TareaController : ControllerBase
    {
        private readonly ITareaRepository _tareaRepository;
        private readonly IProyectoRepository _projectRepository;

        public TareaController(ITareaRepository taskRepository, IProyectoRepository projectRepository)
        {
            _tareaRepository = taskRepository;
            _projectRepository = projectRepository;
        }

        [HttpGet("public-resource")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetProjectTasks(int projectId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var project = await _projectRepository.GetProyectosByIdAsync(projectId);

            if (project == null || project.UserId != userId)
            {
                return NotFound("Proyecto no encontrado o no autorizado.");
            }

            var tasks = await _tareaRepository.GetTareaByIdAsync(projectId);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int projectId, int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var project = await _projectRepository.GetProyectosByIdAsync(projectId);

            if (project == null || project.UserId != userId)
            {
                return NotFound("Proyecto no encontrado o no autorizado.");
            }

            var task = await _tareaRepository.GetTareaByIdAsync(id);
            if (task == null || task.ProyectoId != projectId)
            {
                return NotFound("Tarea no encontrada en este proyecto.");
            }

            return Ok(task);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTask(int projectId, [FromBody] Tarea task)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var project = await _projectRepository.GetProyectosByIdAsync(projectId);

            if (project == null || project.UserId != userId)
            {
                return NotFound("Proyecto no encontrado o no autorizado.");
            }

            task.ProyectoId = projectId;
            task.UserId = userId;
            await _tareaRepository.AddTareaAsync(task);
            return CreatedAtAction(nameof(GetTask), new { projectId = projectId, id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int projectId, int id, [FromBody] Tarea task)
        {
             var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var existingTask = await _tareaRepository.GetTareaByIdAsync(id);

            if (existingTask == null || existingTask.ProyectoId != projectId || existingTask.UserId != userId)
            {
                return NotFound("Tarea no encontrada o no autorizada.");
            }

            existingTask.Titulo = task.Titulo;
            existingTask.Descripcion = task.Descripcion;
            existingTask.Estado = task.Estado;

            await _tareaRepository.UpdateTareaAsync(existingTask);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int projectId, int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var task = await _tareaRepository.GetTareaByIdAsync(id);

            if (task == null || task.ProyectoId != projectId || task.UserId != userId)
            {
                return NotFound("Tarea no encontrada o no autorizada.");
            }

            await _tareaRepository.DeleteTareaAsync(id);
            return NoContent();
        }

    }
}
