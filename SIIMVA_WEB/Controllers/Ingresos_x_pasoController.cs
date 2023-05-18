using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ingresos_x_pasoController : Controller
    {
        private IIngresos_x_pasoService _Ingresos_x_pasoService;
        public Ingresos_x_pasoController(IIngresos_x_pasoService Ingresos_x_pasoService)
        {
            _Ingresos_x_pasoService = Ingresos_x_pasoService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Ingresos_x_paso = _Ingresos_x_pasoService.getByPk(ID);
            if (Ingresos_x_paso == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Ingresos_x_paso);
        }
        [HttpGet]
        public IActionResult read(int idPaso)
        {
            var Ingresos_x_paso = _Ingresos_x_pasoService.read(idPaso);
            if (Ingresos_x_paso == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Ingresos_x_paso);
        }






    }
}

