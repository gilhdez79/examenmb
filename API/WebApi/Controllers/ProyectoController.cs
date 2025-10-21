using Microsoft.AspNetCore.Mvc;
using WebApi.Interface;

namespace WebApi.Controllers
{
    public class ProyectoController : ControllerBase
    {
        private readonly IProyectoRepository _proyectoRepository;
        public ProyectoController(IProyectoRepository proyectoRepository)
        {
            _proyectoRepository = proyectoRepository;
        }

    }
}
