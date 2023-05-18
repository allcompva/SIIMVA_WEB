using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Ws_contenido_campo_formulario : DALBase
    {
        public int ID { get; set; }
        public int ID_CONFIGURA_CAMPO_X_FORMULARIO { get; set; }
        public string VALUE { get; set; }
        public string TEXT { get; set; }
        public int ID_CAMPO_FORMULARIO { get; set; }
        public int id_padre { get; set; }

        public Ws_contenido_campo_formulario()
        {
            ID = 0;
            ID_CONFIGURA_CAMPO_X_FORMULARIO = 0;
            VALUE = string.Empty;
            TEXT = string.Empty;
            ID_CAMPO_FORMULARIO = 0;
            id_padre = 0;
        }

        private static List<Ws_contenido_campo_formulario> mapeo(SqlDataReader dr)
        {
            List<Ws_contenido_campo_formulario> lst = new List<Ws_contenido_campo_formulario>();
            Ws_contenido_campo_formulario obj;
            if (dr.HasRows)
            {
                int ID = dr.GetOrdinal("id");
                int ID_CONFIGURA_CAMPO_X_FORMULARIO = dr.GetOrdinal("ID_CONFIGURA_CAMPO_X_FORMULARIO");
                int VALUE = dr.GetOrdinal("value");
                int TEXT = dr.GetOrdinal("text");
                int ID_CAMPO_FORMULARIO = dr.GetOrdinal("ID_CAMPO_FORMULARIO");
                int id_padre = dr.GetOrdinal("id_padre");

                while (dr.Read())
                {
                    obj = new Ws_contenido_campo_formulario();
                    if (!dr.IsDBNull(ID)) { obj.ID = dr.GetInt32(ID); }
                    if (!dr.IsDBNull(ID_CONFIGURA_CAMPO_X_FORMULARIO)) { obj.ID_CONFIGURA_CAMPO_X_FORMULARIO = dr.GetInt32(ID_CONFIGURA_CAMPO_X_FORMULARIO); }
                    if (!dr.IsDBNull(VALUE)) { obj.VALUE = dr.GetString(VALUE); }
                    if (!dr.IsDBNull(TEXT)) { obj.TEXT = dr.GetString(TEXT); }
                    if (!dr.IsDBNull(ID_CAMPO_FORMULARIO)) { obj.ID_CAMPO_FORMULARIO = dr.GetInt32(ID_CAMPO_FORMULARIO); }
                    if (!dr.IsDBNull(id_padre)) { obj.id_padre = dr.GetInt32(id_padre); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Ws_contenido_campo_formulario> read()
        {
            try
            {
                List<Ws_contenido_campo_formulario> lst = new List<Ws_contenido_campo_formulario>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Ws_contenido_campo_formulario";
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

        public static Ws_contenido_campo_formulario getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Ws_contenido_campo_formulario WHERE");
                Ws_contenido_campo_formulario obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Ws_contenido_campo_formulario> lst = mapeo(dr);
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

        public static int insert(Ws_contenido_campo_formulario obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Ws_contenido_campo_formulario(");
                sql.AppendLine("id");
                sql.AppendLine(", ID_CONFIGURA_CAMPO_X_FORMULARIO");
                sql.AppendLine(", value");
                sql.AppendLine(", text");
                sql.AppendLine(", ID_CAMPO_FORMULARIO");
                sql.AppendLine(", id_padre");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id");
                sql.AppendLine(", @ID_CONFIGURA_CAMPO_X_FORMULARIO");
                sql.AppendLine(", @value");
                sql.AppendLine(", @text");
                sql.AppendLine(", @ID_CAMPO_FORMULARIO");
                sql.AppendLine(", @id_padre");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.ID);
                    cmd.Parameters.AddWithValue("@ID_CONFIGURA_CAMPO_X_FORMULARIO", obj.ID_CONFIGURA_CAMPO_X_FORMULARIO);
                    cmd.Parameters.AddWithValue("@value", obj.VALUE);
                    cmd.Parameters.AddWithValue("@text", obj.TEXT);
                    cmd.Parameters.AddWithValue("@ID_CAMPO_FORMULARIO", obj.ID_CAMPO_FORMULARIO);
                    cmd.Parameters.AddWithValue("@id_padre", obj.id_padre);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Ws_contenido_campo_formulario obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Ws_contenido_campo_formulario SET");
                sql.AppendLine("id=@id");
                sql.AppendLine(", ID_CONFIGURA_CAMPO_X_FORMULARIO=@ID_CONFIGURA_CAMPO_X_FORMULARIO");
                sql.AppendLine(", value=@value");
                sql.AppendLine(", text=@text");
                sql.AppendLine(", ID_CAMPO_FORMULARIO=@ID_CAMPO_FORMULARIO");
                sql.AppendLine(", id_padre=@id_padre");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.ID);
                    cmd.Parameters.AddWithValue("@ID_CONFIGURA_CAMPO_X_FORMULARIO", obj.ID_CONFIGURA_CAMPO_X_FORMULARIO);
                    cmd.Parameters.AddWithValue("@value", obj.VALUE);
                    cmd.Parameters.AddWithValue("@text", obj.TEXT);
                    cmd.Parameters.AddWithValue("@ID_CAMPO_FORMULARIO", obj.ID_CAMPO_FORMULARIO);
                    cmd.Parameters.AddWithValue("@id_padre", obj.id_padre);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Ws_contenido_campo_formulario obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Ws_contenido_campo_formulario ");
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

