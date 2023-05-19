namespace MOTOR_WORKFLOW.Entities
{
    public class contenido_ingreso_paso_model
    {
        public int id { get; set; }
        public int id_ingreso_paso { get; set; }
        public int orden { get; set; }
        public int row { get; set; }
        public int col { get; set; }
        public bool activo { get; set; }
    }
}
