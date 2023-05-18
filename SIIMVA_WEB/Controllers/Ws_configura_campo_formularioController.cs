using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ws_configura_campo_formularioController : Controller
    {
        private IWs_configura_campo_formularioService _Ws_configura_campo_formularioService;
        public Ws_configura_campo_formularioController(IWs_configura_campo_formularioService Ws_configura_campo_formularioService)
        {
            _Ws_configura_campo_formularioService = Ws_configura_campo_formularioService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Ws_configura_campo_formulario = _Ws_configura_campo_formularioService.getByPk(ID);
            if (Ws_configura_campo_formulario == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Ws_configura_campo_formulario);
        }







    }
}

