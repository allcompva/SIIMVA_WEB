using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Formularios : DALBase
    {
        public int id { get; set; }
        public int id_pasos { get; set; }
        public int id_formulario { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public List<Respuesta_formulario> lstRespuesta { get; set; }
        public Formularios()
        {
            id = 0;
            id_pasos = 0;
            id_formulario = 0;
            nombre = string.Empty;
            descripcion = string.Empty;
            lstRespuesta = new List<Respuesta_formulario>();
        }

        private static List<Formularios> mapeo(SqlDataReader dr)
        {
            List<Formularios> lst = new List<Formularios>();
            Formularios obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int id_pasos = dr.GetOrdinal("id_pasos");
                int id_formulario = dr.GetOrdinal("id_formulario");
                int nombre = dr.GetOrdinal("nombre");
                int descripcion = dr.GetOrdinal("descripcion");
                while (dr.Read())
                {
                    obj = new Formularios();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(id_pasos)) { obj.id_pasos = dr.GetInt32(id_pasos); }
                    if (!dr.IsDBNull(id_formulario)) { obj.id_formulario = dr.GetInt32(id_formulario); }
                    if (!dr.IsDBNull(nombre)) { obj.nombre = dr.GetString(nombre); }
                    if (!dr.IsDBNull(descripcion)) { obj.descripcion = dr.GetString(descripcion); }
                    obj.lstRespuesta = Respuesta_formulario.read(obj.id);
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Formularios> read()
        {
            try
            {
                List<Formularios> lst = new List<Formularios>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Formularios";
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

        public static Formularios getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Formularios WHERE");
                sql.AppendLine("id = @id");
                Formularios obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Formularios> lst = mapeo(dr);
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
        public static Formularios getByIdPasos(
        int id_pasos)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Formularios WHERE");
                sql.AppendLine("id_pasos = @id_pasos");
                Formularios obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_pasos", id_pasos);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Formularios> lst = mapeo(dr);
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
        public static int insert(Formularios obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Formularios(");
                sql.AppendLine("id_pasos");
                sql.AppendLine(", id_formulario");
                sql.AppendLine(", nombre");
                sql.AppendLine(", descripcion");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_pasos");
                sql.AppendLine(", @id_formulario");
                sql.AppendLine(", @nombre");
                sql.AppendLine(", @descripcion");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_pasos", obj.id_pasos);
                    cmd.Parameters.AddWithValue("@id_formulario", obj.id_formulario);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Formularios obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Formularios SET");
                sql.AppendLine("id_pasos=@id_pasos");
                sql.AppendLine(", id_formulario=@id_formulario");
                sql.AppendLine(", nombre=@nombre");
                sql.AppendLine(", descripcion=@descripcion");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_pasos", obj.id_pasos);
                    cmd.Parameters.AddWithValue("@id_formulario", obj.id_formulario);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Formularios obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Formularios ");
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

