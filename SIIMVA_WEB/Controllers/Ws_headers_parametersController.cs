using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ws_headers_parametersController : Controller
    {
        private IWs_headers_parametersService _Ws_headers_parametersService;
        public Ws_headers_parametersController(IWs_headers_parametersService Ws_headers_parametersService)
        {
            _Ws_headers_parametersService = Ws_headers_parametersService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Ws_headers_parameters = _Ws_headers_parametersService.getByPk(ID);
            if (Ws_headers_parameters == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Ws_headers_parameters);
        }







    }
}

