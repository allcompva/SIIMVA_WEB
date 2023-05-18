using Microsoft.AspNetCore.Mvc;
using MOTOR_WORKFLOW.Services;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Entities;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class restController : Controller
    {
        private Irest _restService;
        public restController(Irest restService)
        {
            _restService = restService;
        }
        [HttpGet]
        public IActionResult usuario()
        {
            var usuarios = new Entities.usuarios();
            return Ok(JsonConvert.SerializeObject(usuarios));
        }
    }
}
