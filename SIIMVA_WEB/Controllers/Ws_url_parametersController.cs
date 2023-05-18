using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ws_url_parametersController : Controller
    {
        private IWs_url_parametersService _Ws_url_parametersService;
        public Ws_url_parametersController(IWs_url_parametersService Ws_url_parametersService)
        {
            _Ws_url_parametersService = Ws_url_parametersService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Ws_url_parameters = _Ws_url_parametersService.getByPk(ID);
            if (Ws_url_parameters == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Ws_url_parameters);
        }







    }
}

