using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ws_contenido_campo_formularioController : Controller
    {
        private IWs_contenido_campo_formularioService _Ws_contenido_campo_formularioService;
        public Ws_contenido_campo_formularioController(IWs_contenido_campo_formularioService Ws_contenido_campo_formularioService)
        {
            _Ws_contenido_campo_formularioService = Ws_contenido_campo_formularioService;
        }
        [HttpGet]
        public IActionResult getByPk(
        )
        {
            var Ws_contenido_campo_formulario = _Ws_contenido_campo_formularioService.getByPk();
            if (Ws_contenido_campo_formulario == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Ws_contenido_campo_formulario);
        }







    }
}

