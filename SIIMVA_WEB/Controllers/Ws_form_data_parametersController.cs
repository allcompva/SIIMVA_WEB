using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ws_form_data_parametersController : Controller
    {
        private IWs_form_data_parametersService _Ws_form_data_parametersService;
        public Ws_form_data_parametersController(IWs_form_data_parametersService Ws_form_data_parametersService)
        {
            _Ws_form_data_parametersService = Ws_form_data_parametersService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Ws_form_data_parameters = _Ws_form_data_parametersService.getByPk(ID);
            if (Ws_form_data_parameters == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Ws_form_data_parameters);
        }







    }
}

