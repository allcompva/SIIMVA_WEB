using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Validacion_campo : DALBase
    {
        public int id { get; set; }
        public int id_tipo_campo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public Validacion_campo()
        {
            id = 0;
            id_tipo_campo = 0;
            nombre = string.Empty;
            descripcion = string.Empty;
        }

        private static List<Validacion_campo> mapeo(SqlDataReader dr)
        {
            List<Validacion_campo> lst = new List<Validacion_campo>();
            Validacion_campo obj;
            if (dr.HasRows)
            {
                int ID = dr.GetOrdinal("id");
                int ID_TIPO_CAMPO = dr.GetOrdinal("id_tipo_campo");
                int NOMBRE = dr.GetOrdinal("nombre");
                int DESCRIPCION = dr.GetOrdinal("descripcion");
                while (dr.Read())
                {
                    obj = new Validacion_campo();
                    if (!dr.IsDBNull(ID)) { obj.id = dr.GetInt32(ID); }
                    if (!dr.IsDBNull(ID_TIPO_CAMPO)) { obj.id_tipo_campo = dr.GetInt32(ID_TIPO_CAMPO); }
                    if (!dr.IsDBNull(NOMBRE)) { obj.nombre = dr.GetString(NOMBRE); }
                    if (!dr.IsDBNull(DESCRIPCION)) { obj.descripcion = dr.GetString(DESCRIPCION); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Validacion_campo> read()
        {
            try
            {
                List<Validacion_campo> lst = new List<Validacion_campo>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Validacion_campo";
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

        public static Validacion_campo getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Validacion_campo WHERE");
                sql.AppendLine("id = @id");
                Validacion_campo obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Validacion_campo> lst = mapeo(dr);
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

        public static int insert(Validacion_campo obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Validacion_campo(");
                sql.AppendLine("id_tipo_campo");
                sql.AppendLine(", nombre");
                sql.AppendLine(", descripcion");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_tipo_campo");
                sql.AppendLine(", @nombre");
                sql.AppendLine(", @descripcion");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tipo_campo", obj.id_tipo_campo);
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

        public static void update(Validacion_campo obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Validacion_campo SET");
                sql.AppendLine("id_tipo_campo=@id_tipo_campo");
                sql.AppendLine(", nombre=@nombre");
                sql.AppendLine(", descripcion=@descripcion");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tipo_campo", obj.id_tipo_campo);
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

        public static void delete(Validacion_campo obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Validacion_campo ");
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

