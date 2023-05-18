using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Ws_web_service : DALBase
    {
        public int ID { get; set; }
        public int ID_CONFIGURA_CAMPO_FORMULARIO { get; set; }
        public string NOMBRE { get; set; }
        public string URL { get; set; }
        public string VERBO { get; set; }
        public string TIPO { get; set; }
        public string BODY_JSON { get; set; }

        public Ws_web_service()
        {
            ID = 0;
            ID_CONFIGURA_CAMPO_FORMULARIO = 0;
            NOMBRE = string.Empty;
            URL = string.Empty;
            VERBO = string.Empty;
            TIPO = string.Empty;
            BODY_JSON = string.Empty;
        }

        private static List<Ws_web_service> mapeo(SqlDataReader dr)
        {
            List<Ws_web_service> lst = new List<Ws_web_service>();
            Ws_web_service obj;
            if (dr.HasRows)
            {
                int ID = dr.GetOrdinal("id");
                int ID_CONFIGURA_CAMPO_FORMULARIO = dr.GetOrdinal("ID_CONFIGURA_CAMPO_FORMULARIO");
                int NOMBRE = dr.GetOrdinal("nombre");
                int URL = dr.GetOrdinal("URL");
                int VERBO = dr.GetOrdinal("VERBO");
                int TIPO = dr.GetOrdinal("TIPO");
                int BODY_JSON = dr.GetOrdinal("BODY_JSON");
                while (dr.Read())
                {
                    obj = new Ws_web_service();
                    if (!dr.IsDBNull(ID)) { obj.ID = dr.GetInt32(ID); }
                    if (!dr.IsDBNull(ID_CONFIGURA_CAMPO_FORMULARIO)) { obj.ID_CONFIGURA_CAMPO_FORMULARIO = dr.GetInt32(ID_CONFIGURA_CAMPO_FORMULARIO); }
                    if (!dr.IsDBNull(NOMBRE)) { obj.NOMBRE = dr.GetString(NOMBRE); }
                    if (!dr.IsDBNull(URL)) { obj.URL = dr.GetString(URL); }
                    if (!dr.IsDBNull(VERBO)) { obj.VERBO = dr.GetString(VERBO); }
                    if (!dr.IsDBNull(TIPO)) { obj.TIPO = dr.GetString(TIPO); }
                    if (!dr.IsDBNull(BODY_JSON)) { obj.BODY_JSON = dr.GetString(BODY_JSON); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Ws_web_service> read()
        {
            try
            {
                List<Ws_web_service> lst = new List<Ws_web_service>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Ws_web_service";
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

        public static Ws_web_service getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Ws_web_service WHERE");
                sql.AppendLine("id = @id");
                Ws_web_service obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Ws_web_service> lst = mapeo(dr);
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

        public static int insert(Ws_web_service obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Ws_web_service(");
                sql.AppendLine("ID_CONFIGURA_CAMPO_FORMULARIO");
                sql.AppendLine(", nombre");
                sql.AppendLine(", URL");
                sql.AppendLine(", VERBO");
                sql.AppendLine(", TIPO");
                sql.AppendLine(", BODY_JSON");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID_CONFIGURA_CAMPO_FORMULARIO");
                sql.AppendLine(", @nombre");
                sql.AppendLine(", @URL");
                sql.AppendLine(", @VERBO");
                sql.AppendLine(", @TIPO");
                sql.AppendLine(", @BODY_JSON");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_CONFIGURA_CAMPO_FORMULARIO", obj.ID_CONFIGURA_CAMPO_FORMULARIO);
                    cmd.Parameters.AddWithValue("@nombre", obj.NOMBRE);
                    cmd.Parameters.AddWithValue("@URL", obj.URL);
                    cmd.Parameters.AddWithValue("@VERBO", obj.VERBO);
                    cmd.Parameters.AddWithValue("@TIPO", obj.TIPO);
                    cmd.Parameters.AddWithValue("@BODY_JSON", obj.BODY_JSON);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Ws_web_service obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Ws_web_service SET");
                sql.AppendLine("ID_CONFIGURA_CAMPO_FORMULARIO=@ID_CONFIGURA_CAMPO_FORMULARIO");
                sql.AppendLine(", nombre=@nombre");
                sql.AppendLine(", URL=@URL");
                sql.AppendLine(", VERBO=@VERBO");
                sql.AppendLine(", TIPO=@TIPO");
                sql.AppendLine(", BODY_JSON=@BODY_JSON");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_CONFIGURA_CAMPO_FORMULARIO", obj.ID_CONFIGURA_CAMPO_FORMULARIO);
                    cmd.Parameters.AddWithValue("@nombre", obj.NOMBRE);
                    cmd.Parameters.AddWithValue("@URL", obj.URL);
                    cmd.Parameters.AddWithValue("@VERBO", obj.VERBO);
                    cmd.Parameters.AddWithValue("@TIPO", obj.TIPO);
                    cmd.Parameters.AddWithValue("@BODY_JSON", obj.BODY_JSON);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Ws_web_service obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Ws_web_service ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.ID);
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

