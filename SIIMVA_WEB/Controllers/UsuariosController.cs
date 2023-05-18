using Microsoft.AspNetCore.Mvc;
using MOTOR_WORKFLOW.Services.CIDI;
using Newtonsoft.Json;

namespace MOTOR_WORKFLOW.Controllers
{   [ApiController]
    [Route("[controller]/[action]")]
    public class UsuariosController : Controller
    {
        private IUsuariosServices _usuarioService;
        public UsuariosController(IUsuariosServices usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public IActionResult ObtenerUsuarioCIDI(string Hash)
        {
            var usu =
                _usuarioService.ObtenerUsuario(Hash);
            return Ok(usu);
        }
        [HttpGet]
        public IActionResult ObtenerUsuarioCIDI2(string Hash)
        {
            var usu =
                _usuarioService.ObtenerUsuario2(Hash);
            return Ok(usu);
        }
        [HttpGet]
        public IActionResult TraerFotoPerfil(string Hash, string cuit)
        {
            var usu =
                _usuarioService.TraerFotoPerfil(Hash, cuit);
            return Ok(usu);
        }
    }
}
