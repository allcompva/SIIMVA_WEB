namespace MOTOR_WORKFLOW.Entities
{
    public class PasoModel
    {
        public bool activo { get; set; }
        public bool en_usuario { get; set; }
        public bool es_final { get; set; }
        public int id { get; set; }
        public int id_oficina { get; set; }
        public int id_tramite { get; set; }
        public string nombre { get; set; }
        public int orden { get; set; }
        public int proxima_oficina { get; set; }

        public PasoModel() { 
            activo = false;
            en_usuario = false;
            es_final = false;
            id = 0;
            id_oficina = 0;
            id_tramite = 0;
            nombre = string.Empty;
            orden = 0;
            proxima_oficina = 0;
        }

    }
}
