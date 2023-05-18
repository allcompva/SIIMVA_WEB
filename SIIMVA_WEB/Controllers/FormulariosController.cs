using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FormulariosController : Controller
    {
        private IFormulariosService _FormulariosService;
        public FormulariosController(IFormulariosService FormulariosService)
        {
            _FormulariosService = FormulariosService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int id)
        {
            var Formularios = _FormulariosService.getByPk(id);
            if (Formularios == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Formularios);
        }







    }
}

