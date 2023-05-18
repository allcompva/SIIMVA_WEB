using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Validacion_campoController : Controller
    {
        private IValidacion_campoService _Validacion_campoService;
        public Validacion_campoController(IValidacion_campoService Validacion_campoService)
        {
            _Validacion_campoService = Validacion_campoService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Validacion_campo = _Validacion_campoService.getByPk(ID);
            if (Validacion_campo == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Validacion_campo);
        }







    }
}

