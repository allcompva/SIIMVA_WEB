using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using MOTOR_WORKFLOW.Services;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DdjjController : Controller
    {
        private IDdjjService _DdjjService;
        public DdjjController(IDdjjService DdjjService)
        {
            _DdjjService = DdjjService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int ID)
        {
            var Ddjj = _DdjjService.getByPk(ID);
            if (Ddjj == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Ddjj);
        }







    }
}

