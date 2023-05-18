using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Campos_x_formularioController : Controller
    {
        private ICampos_x_formularioService _Campos_x_formularioService;
        public Campos_x_formularioController(ICampos_x_formularioService Campos_x_formularioService)
        {
            _Campos_x_formularioService = Campos_x_formularioService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Campos_x_formulario = _Campos_x_formularioService.getByPk(ID);
            if (Campos_x_formulario == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Campos_x_formulario);
        }







    }
}

