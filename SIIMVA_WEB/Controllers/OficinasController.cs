using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OficinasController : ControllerBase
    {
        private readonly IWebHostEnvironment _HostEnvironment;
        private IOficinasService _OficinaService;
        public OficinasController(IOficinasService OficinaService)
        {
            _OficinaService = OficinaService;
        }
        [HttpGet]
        public IActionResult read()
        {
            var Oficina = _OficinaService.read();
            if (Oficina == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Oficina);
        }
    }
}

