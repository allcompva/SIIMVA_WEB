using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Adjuntos : DALBase
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int id_pasos { get; set; }
        public int orden { get; set; }
        public string archivo { get; set; }
        public string extenciones_aceptadas { get; set; }
        public bool multiple { get; set; }  
        public Adjuntos()
        {
            id = 0;
            nombre = string.Empty;
            id_pasos = 0;
            orden = 0;
            archivo = string.Empty;
            extenciones_aceptadas = string.Empty;   
            multiple = false;
        }

        private static List<Adjuntos> mapeo(SqlDataReader dr)
        {
            List<Adjuntos> lst = new List<Adjuntos>();
            Adjuntos obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int nombre = dr.GetOrdinal("nombre");
                int id_pasos = dr.GetOrdinal("id_pasos");
                int orden = dr.GetOrdinal("orden");
                int archivo = dr.GetOrdinal("archivo");
                int extenciones_aceptadas = dr.GetOrdinal("extenciones_aceptadas");
                int multiple = dr.GetOrdinal("multiple");
                while (dr.Read())
                {
                    obj = new Adjuntos();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(nombre)) { obj.nombre = dr.GetString(nombre); }
                    if (!dr.IsDBNull(id_pasos)) { obj.id_pasos = dr.GetInt32(id_pasos); }
                    if (!dr.IsDBNull(orden)) { obj.orden = dr.GetInt32(orden); }
                    if (!dr.IsDBNull(archivo)) { obj.archivo = dr.GetString(archivo); }
                    if (!dr.IsDBNull(extenciones_aceptadas)) { obj.extenciones_aceptadas = dr.GetString(extenciones_aceptadas); }
                    if (!dr.IsDBNull(multiple)) { obj.multiple = dr.GetBoolean(multiple); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Adjuntos> read()
        {
            try
            {
                List<Adjuntos> lst = new List<Adjuntos>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Adjuntos";
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

        public static Adjuntos getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Adjuntos WHERE");
                sql.AppendLine("id = @id");
                Adjuntos obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Adjuntos> lst = mapeo(dr);
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
        public static Adjuntos getByIdPasos(
        int id_pasos)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Adjuntos WHERE");
                sql.AppendLine("id_pasos = @id_pasos");
                Adjuntos obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_pasos", id_pasos);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Adjuntos> lst = mapeo(dr);
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
        public static int insert(Adjuntos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Adjuntos(");
                sql.AppendLine("nombre");
                sql.AppendLine(", id_pasos");
                sql.AppendLine(", orden");
                sql.AppendLine(", archivo");
                sql.AppendLine(", extenciones_aceptadas");
                sql.AppendLine(", multiple");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nombre");
                sql.AppendLine(", @id_pasos");
                sql.AppendLine(", @orden");
                sql.AppendLine(", @archivo");
                sql.AppendLine(", @extenciones_aceptadas"); 
                sql.AppendLine(", @multiple");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@id_pasos", obj.id_pasos);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@archivo", obj.archivo);
                    cmd.Parameters.AddWithValue("@extenciones_aceptadas", obj.extenciones_aceptadas);
                    cmd.Parameters.AddWithValue("@multiple", obj.multiple);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Adjuntos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Adjuntos SET");
                sql.AppendLine("nombre=@nombre");
                sql.AppendLine(", id_pasos=@id_pasos");
                sql.AppendLine(", orden=@orden");
                sql.AppendLine(", archivo=@archivo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@id_pasos", obj.id_pasos);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@archivo", obj.archivo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Adjuntos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Adjuntos ");
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

