using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Validacion_x_campo_formularioController : Controller
    {
        private IValidacion_x_campo_formularioService _Validacion_x_campo_formularioService;
        public Validacion_x_campo_formularioController(IValidacion_x_campo_formularioService Validacion_x_campo_formularioService)
        {
            _Validacion_x_campo_formularioService = Validacion_x_campo_formularioService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Validacion_x_campo_formulario = _Validacion_x_campo_formularioService.getByPk(ID);
            if (Validacion_x_campo_formulario == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Validacion_x_campo_formulario);
        }







    }
}

