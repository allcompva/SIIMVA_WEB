using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ws_web_serviceController : Controller
    {
        private IWs_web_serviceService _Ws_web_serviceService;
        public Ws_web_serviceController(IWs_web_serviceService Ws_web_serviceService)
        {
            _Ws_web_serviceService = Ws_web_serviceService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Ws_web_service = _Ws_web_serviceService.getByPk(ID);
            if (Ws_web_service == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Ws_web_service);
        }







    }
}

