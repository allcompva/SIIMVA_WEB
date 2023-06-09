using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Contenido_ingreso_pasoController : Controller
    {
        private IContenido_ingreso_pasoService _Contenido_ingreso_pasoService;
        public Contenido_ingreso_pasoController(IContenido_ingreso_pasoService Contenido_ingreso_pasoService)
        {
            _Contenido_ingreso_pasoService = Contenido_ingreso_pasoService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Contenido_ingreso_paso = _Contenido_ingreso_pasoService.getByPk(ID);
            if (Contenido_ingreso_paso == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Contenido_ingreso_paso);
        }
        [HttpGet]
        public IActionResult read(int id_ingreso_paso)
        {
            var Contenido_ingreso_paso = _Contenido_ingreso_pasoService.read(id_ingreso_paso);
            if (Contenido_ingreso_paso == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Contenido_ingreso_paso);
        }
        [HttpGet]
        public IActionResult maxRow(int id_ingreso_paso)
        {
            int max_row = _Contenido_ingreso_pasoService.maxRow(id_ingreso_paso);
            return Ok(max_row);
        }






    }
}

