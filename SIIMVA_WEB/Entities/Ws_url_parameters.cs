using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Ws_url_parameters : DALBase
    {
        public int ID { get; set; }
        public int ID_WEB_SERVICE { get; set; }
        public string NOMBRE_PARAMETRO { get; set; }
        public string VALOR_PARAMETRO { get; set; }

        public Ws_url_parameters()
        {
            ID = 0;
            ID_WEB_SERVICE = 0;
            NOMBRE_PARAMETRO = string.Empty;
            VALOR_PARAMETRO = string.Empty;
        }

        private static List<Ws_url_parameters> mapeo(SqlDataReader dr)
        {
            List<Ws_url_parameters> lst = new List<Ws_url_parameters>();
            Ws_url_parameters obj;
            if (dr.HasRows)
            {
                int ID = dr.GetOrdinal("id");
                int ID_WEB_SERVICE = dr.GetOrdinal("ID_WEB_SERVICE");
                int NOMBRE_PARAMETRO = dr.GetOrdinal("NOMBRE_PARAMETRO");
                int VALOR_PARAMETRO = dr.GetOrdinal("VALOR_PARAMETRO");
                while (dr.Read())
                {
                    obj = new Ws_url_parameters();
                    if (!dr.IsDBNull(ID)) { obj.ID = dr.GetInt32(ID); }
                    if (!dr.IsDBNull(ID_WEB_SERVICE)) { obj.ID_WEB_SERVICE = dr.GetInt32(ID_WEB_SERVICE); }
                    if (!dr.IsDBNull(NOMBRE_PARAMETRO)) { obj.NOMBRE_PARAMETRO = dr.GetString(NOMBRE_PARAMETRO); }
                    if (!dr.IsDBNull(VALOR_PARAMETRO)) { obj.VALOR_PARAMETRO = dr.GetString(VALOR_PARAMETRO); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Ws_url_parameters> read()
        {
            try
            {
                List<Ws_url_parameters> lst = new List<Ws_url_parameters>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Ws_url_parameters";
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

        public static Ws_url_parameters getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Ws_url_parameters WHERE");
                sql.AppendLine("id = @id");
                Ws_url_parameters obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Ws_url_parameters> lst = mapeo(dr);
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

        public static int insert(Ws_url_parameters obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Ws_url_parameters(");
                sql.AppendLine("ID_WEB_SERVICE");
                sql.AppendLine(", NOMBRE_PARAMETRO");
                sql.AppendLine(", VALOR_PARAMETRO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID_WEB_SERVICE");
                sql.AppendLine(", @NOMBRE_PARAMETRO");
                sql.AppendLine(", @VALOR_PARAMETRO");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_WEB_SERVICE", obj.ID_WEB_SERVICE);
                    cmd.Parameters.AddWithValue("@NOMBRE_PARAMETRO", obj.NOMBRE_PARAMETRO);
                    cmd.Parameters.AddWithValue("@VALOR_PARAMETRO", obj.VALOR_PARAMETRO);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Ws_url_parameters obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Ws_url_parameters SET");
                sql.AppendLine("ID_WEB_SERVICE=@ID_WEB_SERVICE");
                sql.AppendLine(", NOMBRE_PARAMETRO=@NOMBRE_PARAMETRO");
                sql.AppendLine(", VALOR_PARAMETRO=@VALOR_PARAMETRO");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_WEB_SERVICE", obj.ID_WEB_SERVICE);
                    cmd.Parameters.AddWithValue("@NOMBRE_PARAMETRO", obj.NOMBRE_PARAMETRO);
                    cmd.Parameters.AddWithValue("@VALOR_PARAMETRO", obj.VALOR_PARAMETRO);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Ws_url_parameters obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Ws_url_parameters ");
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

