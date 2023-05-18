using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Ws_configura_campo_formulario : DALBase
    {
        public int ID { get; set; }
        public int ID_CAMPO_X_FORMULARIO { get; set; }
        public string VALUE { get; set; }
        public string TEXT { get; set; }
        public int ORDEN { get; set; }
        public bool ACTIVO { get; set; }
        public string NOMBRE_GRUPO { get; set; }
        public string TIPO_ORIGEN { get; set; }
        public string CAMPO_ENLAZA { get; set; }

        public Ws_configura_campo_formulario()
        {
            ID = 0;
            ID_CAMPO_X_FORMULARIO = 0;
            VALUE = string.Empty;
            TEXT = string.Empty;
            ORDEN = 0;
            ACTIVO = false;
            NOMBRE_GRUPO = string.Empty;
            TIPO_ORIGEN = string.Empty;
            CAMPO_ENLAZA = string.Empty;
        }

        private static List<Ws_configura_campo_formulario> mapeo(SqlDataReader dr)
        {
            List<Ws_configura_campo_formulario> lst = new List<Ws_configura_campo_formulario>();
            Ws_configura_campo_formulario obj;
            if (dr.HasRows)
            {
                int ID = dr.GetOrdinal("id");
                int ID_CAMPO_X_FORMULARIO = dr.GetOrdinal("ID_CAMPO_X_FORMULARIO");
                int VALUE = dr.GetOrdinal("value");
                int TEXT = dr.GetOrdinal("text");
                int ORDEN = dr.GetOrdinal("orden");
                int ACTIVO = dr.GetOrdinal("activo");
                int NOMBRE_GRUPO = dr.GetOrdinal("NOMBRE_GRUPO");
                int TIPO_ORIGEN = dr.GetOrdinal("TIPO_ORIGEN");
                int CAMPO_ENLAZA = dr.GetOrdinal("CAMPO_ENLAZA");
                while (dr.Read())
                {
                    obj = new Ws_configura_campo_formulario();
                    if (!dr.IsDBNull(ID)) { obj.ID = dr.GetInt32(ID); }
                    if (!dr.IsDBNull(ID_CAMPO_X_FORMULARIO)) { obj.ID_CAMPO_X_FORMULARIO = dr.GetInt32(ID_CAMPO_X_FORMULARIO); }
                    if (!dr.IsDBNull(VALUE)) { obj.VALUE = dr.GetString(VALUE); }
                    if (!dr.IsDBNull(TEXT)) { obj.TEXT = dr.GetString(TEXT); }
                    if (!dr.IsDBNull(ORDEN)) { obj.ORDEN = dr.GetInt32(ORDEN); }
                    if (!dr.IsDBNull(ACTIVO)) { obj.ACTIVO = dr.GetBoolean(ACTIVO); }
                    if (!dr.IsDBNull(NOMBRE_GRUPO)) { obj.NOMBRE_GRUPO = dr.GetString(NOMBRE_GRUPO); }
                    if (!dr.IsDBNull(TIPO_ORIGEN)) { obj.TIPO_ORIGEN = dr.GetString(TIPO_ORIGEN); }
                    if (!dr.IsDBNull(CAMPO_ENLAZA)) { obj.CAMPO_ENLAZA = dr.GetString(CAMPO_ENLAZA); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Ws_configura_campo_formulario> read()
        {
            try
            {
                List<Ws_configura_campo_formulario> lst = new List<Ws_configura_campo_formulario>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Ws_configura_campo_formulario";
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

        public static Ws_configura_campo_formulario getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Ws_configura_campo_formulario WHERE");
                sql.AppendLine("id = @id");
                Ws_configura_campo_formulario obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Ws_configura_campo_formulario> lst = mapeo(dr);
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

        public static int insert(Ws_configura_campo_formulario obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Ws_configura_campo_formulario(");
                sql.AppendLine("ID_CAMPO_X_FORMULARIO");
                sql.AppendLine(", value");
                sql.AppendLine(", text");
                sql.AppendLine(", orden");
                sql.AppendLine(", activo");
                sql.AppendLine(", NOMBRE_GRUPO");
                sql.AppendLine(", TIPO_ORIGEN");
                sql.AppendLine(", CAMPO_ENLAZA");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID_CAMPO_X_FORMULARIO");
                sql.AppendLine(", @value");
                sql.AppendLine(", @text");
                sql.AppendLine(", @orden");
                sql.AppendLine(", @activo");
                sql.AppendLine(", @NOMBRE_GRUPO");
                sql.AppendLine(", @TIPO_ORIGEN");
                sql.AppendLine(", @CAMPO_ENLAZA");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_CAMPO_X_FORMULARIO", obj.ID_CAMPO_X_FORMULARIO);
                    cmd.Parameters.AddWithValue("@value", obj.VALUE);
                    cmd.Parameters.AddWithValue("@text", obj.TEXT);
                    cmd.Parameters.AddWithValue("@orden", obj.ORDEN);
                    cmd.Parameters.AddWithValue("@activo", obj.ACTIVO);
                    cmd.Parameters.AddWithValue("@NOMBRE_GRUPO", obj.NOMBRE_GRUPO);
                    cmd.Parameters.AddWithValue("@TIPO_ORIGEN", obj.TIPO_ORIGEN);
                    cmd.Parameters.AddWithValue("@CAMPO_ENLAZA", obj.CAMPO_ENLAZA);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Ws_configura_campo_formulario obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Ws_configura_campo_formulario SET");
                sql.AppendLine("ID_CAMPO_X_FORMULARIO=@ID_CAMPO_X_FORMULARIO");
                sql.AppendLine(", value=@value");
                sql.AppendLine(", text=@text");
                sql.AppendLine(", orden=@orden");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine(", NOMBRE_GRUPO=@NOMBRE_GRUPO");
                sql.AppendLine(", TIPO_ORIGEN=@TIPO_ORIGEN");
                sql.AppendLine(", CAMPO_ENLAZA=@CAMPO_ENLAZA");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_CAMPO_X_FORMULARIO", obj.ID_CAMPO_X_FORMULARIO);
                    cmd.Parameters.AddWithValue("@value", obj.VALUE);
                    cmd.Parameters.AddWithValue("@text", obj.TEXT);
                    cmd.Parameters.AddWithValue("@orden", obj.ORDEN);
                    cmd.Parameters.AddWithValue("@activo", obj.ACTIVO);
                    cmd.Parameters.AddWithValue("@NOMBRE_GRUPO", obj.NOMBRE_GRUPO);
                    cmd.Parameters.AddWithValue("@TIPO_ORIGEN", obj.TIPO_ORIGEN);
                    cmd.Parameters.AddWithValue("@CAMPO_ENLAZA", obj.CAMPO_ENLAZA);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Ws_configura_campo_formulario obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Ws_configura_campo_formulario ");
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

