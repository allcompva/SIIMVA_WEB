using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class ddjj : DALBase
    {
        public int id { get; set; }
        public string texto { get; set; }
        public int id_contenido_ingreso_paso { get; set; }
        public ddjj()
        {
            id = 0;
            texto = string.Empty;
        }

        private static List<ddjj> mapeo(SqlDataReader dr)
        {
            List<ddjj> lst = new List<ddjj>();
            ddjj obj;
            if (dr.HasRows)
            {
                int ID = dr.GetOrdinal("id");
                int TEXTO = dr.GetOrdinal("texto");
                int ID_CONTENIDO_INGRESO_PASO = dr.GetOrdinal("ID_CONTENIDO_INGRESO_PASO");
                while (dr.Read())
                {
                    obj = new ddjj();
                    if (!dr.IsDBNull(ID)) { obj.id = dr.GetInt32(ID); }
                    if (!dr.IsDBNull(TEXTO)) { obj.texto = dr.GetString(TEXTO); }
                    if (!dr.IsDBNull(ID_CONTENIDO_INGRESO_PASO)) { obj.id_contenido_ingreso_paso = dr.GetInt32(ID_CONTENIDO_INGRESO_PASO); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<ddjj> read()
        {
            try
            {
                List<ddjj> lst = new List<ddjj>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM ddjj";
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

        public static ddjj getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM ddjj WHERE");
                sql.AppendLine("id = @id");
                ddjj obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ddjj> lst = mapeo(dr);
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

        public static int insert(ddjj obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO ddjj(");
                sql.AppendLine("texto,");
                sql.AppendLine("ID_CONTENIDO_INGRESO_PASO)");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@texto,");
                sql.AppendLine("@ID_CONTENIDO_INGRESO_PASO)");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@texto", obj.texto);
                    cmd.Parameters.AddWithValue("@ID_CONTENIDO_INGRESO_PASO", obj.id_contenido_ingreso_paso);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(ddjj obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  ddjj SET");
                sql.AppendLine("texto=@texto");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@texto", obj.texto);
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

        public static void delete(ddjj obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  ddjj ");
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

