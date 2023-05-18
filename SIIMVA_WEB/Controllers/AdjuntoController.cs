using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdjuntoController : Controller
    {
        private IAdjuntoService _AdjuntoService;
        public AdjuntoController(IAdjuntoService AdjuntoService)
        {
            _AdjuntoService = AdjuntoService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Adjunto = _AdjuntoService.getByPk(ID);
            if (Adjunto == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Adjunto);
        }







    }
}

