using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PasosController : Controller
    {
        private IPasosService _PasosService;
        public PasosController(IPasosService PasosService)
        {
            _PasosService = PasosService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int id)
        {
            var Pasos = _PasosService.getByPk(id);
            if (Pasos == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Pasos);
        }


    }
}

