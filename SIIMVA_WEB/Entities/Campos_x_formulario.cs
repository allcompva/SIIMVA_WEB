using RestSharp;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace MOTOR_WORKFLOW.Entities
{
    public class campos_x_formulario : DALBase
    {
        public int id { get; set; }
        public int id_formulario { get; set; }
        public int id_tipo_campo { get; set; }
        public string nombre { get; set; }
        public string etiqueta { get; set; }
        public string place_holder { get; set; }
        public int orden { get; set; }
        public bool activo { get; set; }
        public bool requerido { get; set; }
        public int id_ws { get; set; }
        public string value { get; set; }
        public string text { get; set; }
        public bool carga_manual { get; set; }
        public string contenido_campo { get; set; }
        public string ingreso_usuario { get; set; }
        public int min_value { get; set; }
        public int max_value { get; set; }
        public int min_length { get; set; }
        public int max_length { get; set; }
        public string mensaje_error { get; set; }
        public DateTime? min_fecha { get; set; }
        public DateTime? max_fecha { get; set; }
        public string formato_resultado { get; set; }
        public int row { get; set; }
        public int col { get; set; }

        public campos_x_formulario()
        {
            id = 0;
            id_formulario = 0;
            id_tipo_campo = 0;
            nombre = string.Empty;
            etiqueta = string.Empty;
            place_holder = string.Empty;
            orden = 0;
            activo = false;
            requerido = false;
            id_ws = 0;
            value = string.Empty;
            text = string.Empty;
            carga_manual = false;
            contenido_campo = string.Empty;
            ingreso_usuario = string.Empty;
            min_value = 0;
            max_value = 0;  
            min_length = 0;
            max_length = 0;
            min_fecha = null;
            max_fecha = null;
            mensaje_error = string.Empty;
            formato_resultado = string.Empty;
            row = 0;
            col = 0;
        }

        private static List<campos_x_formulario> mapeo(SqlDataReader dr)
        {
            List<campos_x_formulario> lst = new List<campos_x_formulario>();
            campos_x_formulario obj;
            if (dr.HasRows)
            {
                int ID = dr.GetOrdinal("id");
                int ID_FORMULARIO = dr.GetOrdinal("id_formulario");
                int ID_TIPO_CAMPO = dr.GetOrdinal("id_tipo_campo");
                int NOMBRE = dr.GetOrdinal("nombre");
                int ETIQUETA = dr.GetOrdinal("etiqueta");
                int PLACE_HOLDER = dr.GetOrdinal("place_holder");
                int ORDEN = dr.GetOrdinal("orden");
                int ACTIVO = dr.GetOrdinal("activo");
                int REQUERIDO = dr.GetOrdinal("requerido");
                int ID_WS = dr.GetOrdinal("id_ws");
                int VALUE = dr.GetOrdinal("value");
                int TEXT = dr.GetOrdinal("text");
                int CARGA_MANUAL = dr.GetOrdinal("carga_manual");
                int CONTENIDO_CAMPO = dr.GetOrdinal("contenido_campo");

                int MIN_VALUE = dr.GetOrdinal("min_value");
                int MAX_VALUE = dr.GetOrdinal("max_value");
                int MIN_LENGTH = dr.GetOrdinal("min_length");
                int MAX_LENGTH = dr.GetOrdinal("max_length");
                int MIN_FECHA = dr.GetOrdinal("min_fecha");
                int MAX_FECHA = dr.GetOrdinal("max_fecha");

                int MENSAJE_ERROR = dr.GetOrdinal("MENSAJE_ERROR");

                int FORMATO_RESULTADO = dr.GetOrdinal("formato_resultado");

                int row = dr.GetOrdinal("row");
                int col = dr.GetOrdinal("col");

                while (dr.Read())
                {
                    obj = new campos_x_formulario();
                    if (!dr.IsDBNull(ID)) { obj.id = dr.GetInt32(ID); }
                    if (!dr.IsDBNull(ID_FORMULARIO)) { obj.id_formulario = dr.GetInt32(ID_FORMULARIO); }
                    if (!dr.IsDBNull(ID_TIPO_CAMPO)) { obj.id_tipo_campo = dr.GetInt32(ID_TIPO_CAMPO); }
                    if (!dr.IsDBNull(NOMBRE)) { obj.nombre = dr.GetString(NOMBRE); }
                    if (!dr.IsDBNull(ETIQUETA)) { obj.etiqueta = dr.GetString(ETIQUETA); }
                    if (!dr.IsDBNull(PLACE_HOLDER)) { obj.place_holder = dr.GetString(PLACE_HOLDER); }
                    if (!dr.IsDBNull(ORDEN)) { obj.orden = dr.GetInt32(ORDEN); }
                    if (!dr.IsDBNull(ACTIVO)) { obj.activo = dr.GetBoolean(ACTIVO); }
                    if (!dr.IsDBNull(REQUERIDO)) { obj.requerido = dr.GetBoolean(REQUERIDO); }
                    if (!dr.IsDBNull(ID_WS)) { obj.id_ws = dr.GetInt32(ID_WS); }
                    if (!dr.IsDBNull(VALUE)) { obj.value = dr.GetString(VALUE); }
                    if (!dr.IsDBNull(TEXT)) { obj.text = dr.GetString(TEXT); }
                    if (!dr.IsDBNull(CARGA_MANUAL)) { obj.carga_manual = dr.GetBoolean(CARGA_MANUAL); }
                    if (!dr.IsDBNull(CONTENIDO_CAMPO)) { obj.contenido_campo = dr.GetString(CONTENIDO_CAMPO); }

                    if (!dr.IsDBNull(MIN_VALUE)) { obj.min_value = dr.GetInt32(MIN_VALUE); }
                    if (!dr.IsDBNull(MAX_VALUE)) { obj.max_value = dr.GetInt32(MAX_VALUE); }
                    if (!dr.IsDBNull(MIN_LENGTH)) { obj.min_length = dr.GetInt32(MIN_LENGTH); }
                    if (!dr.IsDBNull(MAX_LENGTH)) { obj.max_length = dr.GetInt32(MAX_LENGTH); }
                    if (!dr.IsDBNull(MIN_FECHA)) { obj.min_fecha = dr.GetDateTime(MIN_FECHA); }
                    if (!dr.IsDBNull(MAX_FECHA)) { obj.max_fecha = dr.GetDateTime(MAX_FECHA); }

                    if (!dr.IsDBNull(MENSAJE_ERROR)) { obj.mensaje_error = dr.GetString(MENSAJE_ERROR); }

                    if (!dr.IsDBNull(FORMATO_RESULTADO)) { obj.formato_resultado = dr.GetString(FORMATO_RESULTADO); }

                    if (!dr.IsDBNull(row)) { obj.row = dr.GetInt32(row); }
                    if (!dr.IsDBNull(col)) { obj.col = dr.GetInt32(col); }

                    if (obj.id_ws != 0)
                    {
                        Ws_web_service objWs = Ws_web_service.getByPk(obj.id_ws);
                        var client = new RestClient(objWs.URL);
                        var request = new RestRequest();
                        request.Method = Method.Get;
                        RestResponse response = client.Execute(request);
                        obj.contenido_campo = response.Content;
                    }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<campos_x_formulario> read(int idFormulario)
        {
            try
            {
                List<campos_x_formulario> lst = new List<campos_x_formulario>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM campos_x_formulario WHERE id_formulario = @id_formulario";
                    cmd.Parameters.AddWithValue("@id_formulario", idFormulario);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static campos_x_formulario getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM campos_x_formulario WHERE");
                sql.AppendLine("id = @id");
                campos_x_formulario obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<campos_x_formulario> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(campos_x_formulario obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO campos_x_formulario(");
                sql.AppendLine("id_formulario");
                sql.AppendLine(", id_tipo_campo");
                sql.AppendLine(", nombre");
                sql.AppendLine(", etiqueta");
                sql.AppendLine(", place_holder");
                sql.AppendLine(", orden");
                sql.AppendLine(", activo");
                sql.AppendLine(", requerido");
                sql.AppendLine(", id_ws");
                sql.AppendLine(", value");
                sql.AppendLine(", text");
                sql.AppendLine(", carga_manual");
                sql.AppendLine(", contenido_campo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_formulario");
                sql.AppendLine(", @id_tipo_campo");
                sql.AppendLine(", @nombre");
                sql.AppendLine(", @etiqueta");
                sql.AppendLine(", @place_holder");
                sql.AppendLine(", @orden");
                sql.AppendLine(", @activo");
                sql.AppendLine(", @requerido");
                sql.AppendLine(", @id_ws");
                sql.AppendLine(", @value");
                sql.AppendLine(", @text");
                sql.AppendLine(", @carga_manual");
                sql.AppendLine(", @contenido_campo");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_formulario", obj.id_formulario);
                    cmd.Parameters.AddWithValue("@id_tipo_campo", obj.id_tipo_campo);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@etiqueta", obj.etiqueta);
                    cmd.Parameters.AddWithValue("@place_holder", obj.place_holder);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@requerido", obj.requerido);
                    cmd.Parameters.AddWithValue("@id_ws", obj.id_ws);
                    cmd.Parameters.AddWithValue("@value", obj.value);
                    cmd.Parameters.AddWithValue("@text", obj.text);
                    cmd.Parameters.AddWithValue("@carga_manual", obj.carga_manual);
                    cmd.Parameters.AddWithValue("@contenido_campo", obj.contenido_campo);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(campos_x_formulario obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  campos_x_formulario SET");
                sql.AppendLine("id_formulario=@id_formulario");
                sql.AppendLine(", id_tipo_campo=@id_tipo_campo");
                sql.AppendLine(", nombre=@nombre");
                sql.AppendLine(", etiqueta=@etiqueta");
                sql.AppendLine(", place_holder=@place_holder");
                sql.AppendLine(", orden=@orden");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine(", requerido=@requerido");
                sql.AppendLine(", id_ws=@id_ws");
                sql.AppendLine(", value=@value");
                sql.AppendLine(", text=@text");
                sql.AppendLine(", carga_manual=@carga_manual");
                sql.AppendLine(", contenido_campo=@contenido_campo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_formulario", obj.id_formulario);
                    cmd.Parameters.AddWithValue("@id_tipo_campo", obj.id_tipo_campo);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@etiqueta", obj.etiqueta);
                    cmd.Parameters.AddWithValue("@place_holder", obj.place_holder);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@requerido", obj.requerido);
                    cmd.Parameters.AddWithValue("@id_ws", obj.id_ws);
                    cmd.Parameters.AddWithValue("@value", obj.value);
                    cmd.Parameters.AddWithValue("@text", obj.text);
                    cmd.Parameters.AddWithValue("@carga_manual", obj.carga_manual);
                    cmd.Parameters.AddWithValue("@contenido_campo", obj.contenido_campo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(campos_x_formulario obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  campos_x_formulario ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

