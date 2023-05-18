namespace MOTOR_WORKFLOW.Entities
{
    public class ingreso_paso_model
    {
        public int id { get; set; }
        public int id_paso { get; set; }
        public string titulo { get; set; }
        public int orden { get; set; }
        public bool activo { get; set; }

        public ingreso_paso_model()
        {
            id = 0;
            id_paso = 0;
            titulo = string.Empty;
            orden = 0;
            activo = false;
        }
    }
}
