namespace MOTOR_WORKFLOW.Entities
{
    public class RespuestaTramite
    {
        public int id { get; set; }
        public int id_ingreso_paso { get; set; }
        public int id_formulario { get; set; }
        public int id_adjunto { get; set; }
        public int id_ddjj { get; set; }
        public int orden { get; set; }
        public int row { get; set; }
        public int col { get; set; }
        public bool activo { get; set; }
        public Formularios objFormulario { get; set; }
        public Adjuntos objAdjunto { get; set; }
        public Ddjjs objDDJJ { get; set; }
    }
}
