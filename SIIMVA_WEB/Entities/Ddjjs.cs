using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Ddjjs : DALBase
    {
        public int id { get; set; }
        public int id_pasos { get; set; }
        public string ddjj { get; set; }
        public string orden { get; set; }

        public Ddjjs()
        {
            id = 0;
            id_pasos = 0;
            ddjj = string.Empty;
            orden = string.Empty;
        }

        private static List<Ddjjs> mapeo(SqlDataReader dr)
        {
            List<Ddjjs> lst = new List<Ddjjs>();
            Ddjjs obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int id_pasos = dr.GetOrdinal("id_pasos");
                int ddjj = dr.GetOrdinal("ddjj");
                int orden = dr.GetOrdinal("orden");
                while (dr.Read())
                {
                    obj = new Ddjjs();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(id_pasos)) { obj.id_pasos = dr.GetInt32(id_pasos); }
                    if (!dr.IsDBNull(ddjj)) { obj.ddjj = dr.GetString(ddjj); }
                    if (!dr.IsDBNull(orden)) { obj.orden = dr.GetString(orden); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Ddjjs> read()
        {
            try
            {
                List<Ddjjs> lst = new List<Ddjjs>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Ddjjs";
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

        public static Ddjjs getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Ddjjs WHERE");
                sql.AppendLine("id = @id");
                Ddjjs obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Ddjjs> lst = mapeo(dr);
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
        public static Ddjjs getByIdPasos(
        int id_pasos)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Ddjjs WHERE");
                sql.AppendLine("id_pasos = @id_pasos");
                Ddjjs obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_pasos", id_pasos);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Ddjjs> lst = mapeo(dr);
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
        public static int insert(Ddjjs obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Ddjjs(");
                sql.AppendLine("id_pasos");
                sql.AppendLine(", ddjj");
                sql.AppendLine(", orden");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_pasos");
                sql.AppendLine(", @ddjj");
                sql.AppendLine(", @orden");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_pasos", obj.id_pasos);
                    cmd.Parameters.AddWithValue("@ddjj", obj.ddjj);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Ddjjs obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Ddjjs SET");
                sql.AppendLine("id_pasos=@id_pasos");
                sql.AppendLine(", ddjj=@ddjj");
                sql.AppendLine(", orden=@orden");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_pasos", obj.id_pasos);
                    cmd.Parameters.AddWithValue("@ddjj", obj.ddjj);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Ddjjs obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Ddjjs ");
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

