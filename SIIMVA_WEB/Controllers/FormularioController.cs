using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FormularioController : Controller
    {
        private IFormularioService _FormularioService;
        public FormularioController(IFormularioService FormularioService)
        {
            _FormularioService = FormularioService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Formulario = _FormularioService.getByPk(ID);
            if (Formulario == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Formulario);
        }







    }
}

