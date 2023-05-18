namespace MOTOR_WORKFLOW.Services.CIDI
{
    public interface IUsuariosServices
    {
        public Entities.CIDI.Usuario ObtenerUsuario2(string HashCookie);
        public string ObtenerUsuario(string HashCookie);
        public string TraerFotoPerfil(string hash, string cuit);
    }
}
