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
    public class TramitesController : Controller
    {
        private ITramitesService _TramitesService;
        public TramitesController(ITramitesService TramitesService)
        {
            _TramitesService = TramitesService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int id)
        {
            var Tramites = _TramitesService.getByPk(id);
            if (Tramites == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tramites);
        }
        [HttpGet]
        public IActionResult read(string cuit)
        {
            var Tramites = _TramitesService.read(cuit);
            if (Tramites == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tramites);
        }
        [HttpGet]
        public IActionResult readAdministrador()
        {
            var Tramites = _TramitesService.read();
            if (Tramites == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tramites);
        }
        [HttpGet]
        public IActionResult readOficinas(int id_oficina)
        {
            var Tramites = _TramitesService.readOficina(id_oficina);
            if (Tramites == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tramites);
        }

        [HttpGet]
        public IActionResult recibir(int id_tramite, int paso_actual,
            int id_tramites, int cod_usuario)
        {
            int Paso = _TramitesService.recibir(id_tramite, paso_actual,
                id_tramites, cod_usuario);
            if (Paso == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Paso);
        }




    }
}

