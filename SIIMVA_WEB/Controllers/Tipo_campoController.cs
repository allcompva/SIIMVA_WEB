using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tipo_campoController : Controller
    {
        private ITipo_campoService _Tipo_campoService;
        public Tipo_campoController(ITipo_campoService Tipo_campoService)
        {
            _Tipo_campoService = Tipo_campoService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Tipo_campo = _Tipo_campoService.getByPk(ID);
            if (Tipo_campo == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tipo_campo);
        }







    }
}

