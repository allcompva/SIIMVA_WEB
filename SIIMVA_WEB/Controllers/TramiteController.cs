using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;
using MOTOR_WORKFLOW.Entities;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TramiteController : Controller
    {
        private ITramiteService _TramiteService;
        public TramiteController(ITramiteService TramiteService)
        {
            _TramiteService = TramiteService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Tramite = _TramiteService.getByPk(ID);
            if (Tramite == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tramite);
        }
        [HttpGet]
        public IActionResult read()
        {
            var Tramite = _TramiteService.read();
            if (Tramite == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tramite);
        }
        [HttpGet]
        public IActionResult IniciaTramite(
        int ID)
        {
            var Tramite = _TramiteService.getByPk(ID);
            if (Tramite == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tramite);
        }
        [HttpGet]
        public IActionResult getDatosIniciador(
        int ID)
        {
            var Tramite = _TramiteService.getByPk(ID);
            if (Tramite == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tramite);
        }

        [HttpPost]
        public IActionResult insert(Tramite obj)
        {
            try
            {
                _TramiteService.insert(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public IActionResult update(Tramite obj)
        {
            try
            {
                _TramiteService.update(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

