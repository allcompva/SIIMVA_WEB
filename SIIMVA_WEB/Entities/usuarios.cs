namespace MOTOR_WORKFLOW.Entities
{
    public class usuarios
    {
        public List<usuario> rows { get; set; }
        public bool success { get; set; }
        public int total { get; set; }

        public usuarios()
        {
            rows = usuario.getUsuario();
            success = true;
            total = rows.Count;
        }
    }
}
