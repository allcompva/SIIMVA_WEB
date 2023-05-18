using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Validacion_x_campo_formulario : DALBase
    {
        public int id { get; set; }
        public int id_campo_formulario { get; set; }
        public int id_validacion_campo { get; set; }
        public int min_length { get; set; }
        public int max_length { get; set; }
        public int min_value { get; set; }
        public int max_value { get; set; }
        public DateTime min_fecha { get; set; }
        public DateTime max_fecha { get; set; }

        public Validacion_x_campo_formulario()
        {
            id = 0;
            id_campo_formulario = 0;
            id_validacion_campo = 0;
            min_length = 0;
            max_length = 0;
            min_value = 0;
            max_value = 0;
            min_fecha = DateTime.Now;
            max_fecha = DateTime.Now;
        }

        private static List<Validacion_x_campo_formulario> mapeo(SqlDataReader dr)
        {
            List<Validacion_x_campo_formulario> lst = new List<Validacion_x_campo_formulario>();
            Validacion_x_campo_formulario obj;
            if (dr.HasRows)
            {
                int ID = dr.GetOrdinal("id");
                int ID_CAMPO_FORMULARIO = dr.GetOrdinal("id_campo_formulario");
                int ID_VALIDACION_CAMPO = dr.GetOrdinal("id_validacion_campo");
                int MIN_LENGTH = dr.GetOrdinal("min_length");
                int MAX_LENGTH = dr.GetOrdinal("max_length");
                int MIN_VALUE = dr.GetOrdinal("min_value");
                int MAX_VALUE = dr.GetOrdinal("max_value");
                int MIN_FECHA = dr.GetOrdinal("min_fecha");
                int MAX_FECHA = dr.GetOrdinal("max_fecha");
                while (dr.Read())
                {
                    obj = new Validacion_x_campo_formulario();
                    if (!dr.IsDBNull(ID)) { obj.id = dr.GetInt32(ID); }
                    if (!dr.IsDBNull(ID_CAMPO_FORMULARIO)) { obj.id_campo_formulario = dr.GetInt32(ID_CAMPO_FORMULARIO); }
                    if (!dr.IsDBNull(ID_VALIDACION_CAMPO)) { obj.id_validacion_campo = dr.GetInt32(ID_VALIDACION_CAMPO); }
                    if (!dr.IsDBNull(MIN_LENGTH)) { obj.min_length = dr.GetInt32(MIN_LENGTH); }
                    if (!dr.IsDBNull(MAX_LENGTH)) { obj.max_length = dr.GetInt32(MAX_LENGTH); }
                    if (!dr.IsDBNull(MIN_VALUE)) { obj.min_value = dr.GetInt32(MIN_VALUE); }
                    if (!dr.IsDBNull(MAX_VALUE)) { obj.max_value = dr.GetInt32(MAX_VALUE); }
                    if (!dr.IsDBNull(MIN_FECHA)) { obj.min_fecha = dr.GetDateTime(MIN_FECHA); }
                    if (!dr.IsDBNull(MAX_FECHA)) { obj.max_fecha = dr.GetDateTime(MAX_FECHA); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Validacion_x_campo_formulario> read()
        {
            try
            {
                List<Validacion_x_campo_formulario> lst = new List<Validacion_x_campo_formulario>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Validacion_x_campo_formulario";
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

        public static Validacion_x_campo_formulario getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Validacion_x_campo_formulario WHERE");
                sql.AppendLine("id = @id");
                Validacion_x_campo_formulario obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Validacion_x_campo_formulario> lst = mapeo(dr);
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

        public static int insert(Validacion_x_campo_formulario obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Validacion_x_campo_formulario(");
                sql.AppendLine("id_campo_formulario");
                sql.AppendLine(", id_validacion_campo");
                sql.AppendLine(", min_length");
                sql.AppendLine(", max_length");
                sql.AppendLine(", min_value");
                sql.AppendLine(", max_value");
                sql.AppendLine(", min_fecha");
                sql.AppendLine(", max_fecha");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_campo_formulario");
                sql.AppendLine(", @id_validacion_campo");
                sql.AppendLine(", @min_length");
                sql.AppendLine(", @max_length");
                sql.AppendLine(", @min_value");
                sql.AppendLine(", @max_value");
                sql.AppendLine(", @min_fecha");
                sql.AppendLine(", @max_fecha");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_campo_formulario", obj.id_campo_formulario);
                    cmd.Parameters.AddWithValue("@id_validacion_campo", obj.id_validacion_campo);
                    cmd.Parameters.AddWithValue("@min_length", obj.min_length);
                    cmd.Parameters.AddWithValue("@max_length", obj.max_length);
                    cmd.Parameters.AddWithValue("@min_value", obj.min_value);
                    cmd.Parameters.AddWithValue("@max_value", obj.max_value);
                    cmd.Parameters.AddWithValue("@min_fecha", obj.min_fecha);
                    cmd.Parameters.AddWithValue("@max_fecha", obj.max_fecha);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Validacion_x_campo_formulario obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Validacion_x_campo_formulario SET");
                sql.AppendLine("id_campo_formulario=@id_campo_formulario");
                sql.AppendLine(", id_validacion_campo=@id_validacion_campo");
                sql.AppendLine(", min_length=@min_length");
                sql.AppendLine(", max_length=@max_length");
                sql.AppendLine(", min_value=@min_value");
                sql.AppendLine(", max_value=@max_value");
                sql.AppendLine(", min_fecha=@min_fecha");
                sql.AppendLine(", max_fecha=@max_fecha");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_campo_formulario", obj.id_campo_formulario);
                    cmd.Parameters.AddWithValue("@id_validacion_campo", obj.id_validacion_campo);
                    cmd.Parameters.AddWithValue("@min_length", obj.min_length);
                    cmd.Parameters.AddWithValue("@max_length", obj.max_length);
                    cmd.Parameters.AddWithValue("@min_value", obj.min_value);
                    cmd.Parameters.AddWithValue("@max_value", obj.max_value);
                    cmd.Parameters.AddWithValue("@min_fecha", obj.min_fecha);
                    cmd.Parameters.AddWithValue("@max_fecha", obj.max_fecha);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Validacion_x_campo_formulario obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Validacion_x_campo_formulario ");
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

