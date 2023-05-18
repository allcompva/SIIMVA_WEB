using Microsoft.AspNetCore.Mvc;
using MOTOR_WORKFLOW.Services.CIDI;
using MOTOR_WORKFLOW.Services.LOGIN;

namespace MOTOR_WORKFLOW.Controllers
{
    [ApiController]
    //[Route("[controller]/[action]")]
    //[Route("api/[controller]/[action]")]
    [Route("[controller]/[action]")]

    public class LoginController : ControllerBase
    {
        private readonly IUsuarioConOficina _iusuarioConOficinaService;
        public LoginController(IUsuarioConOficina iusuarioConOficinaService)
        {
            _iusuarioConOficinaService = iusuarioConOficinaService;
        }
        [HttpGet]
        public IActionResult ValidaUsuarioConOficina(string user, string password)
        {
            var resultado = _iusuarioConOficinaService.ValidUser(user, password);
            return Ok(resultado);
        }
        [HttpGet]
        public IActionResult ValidaPermisoConOficina(string user, string proceso)
        {
            var resultado = _iusuarioConOficinaService.ValidaPermiso(user, proceso);
            return Ok(resultado);
        }

    }
}
