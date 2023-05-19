using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class ingresos_x_paso : DALBase
    {
        public int id { get; set; }
        public int id_paso { get; set; }
        public string titulo { get; set; }
        public string subtitulo { get; set; }
        public int orden { get; set; }
        public bool activo { get; set; }
        public List<contenido_ingreso_paso> lstContenido { get; set; }

        public ingresos_x_paso()
        {
            id = 0;
            id_paso = 0;
            titulo = string.Empty; 
            subtitulo = string.Empty;
            orden = 0;
            activo = true;
            lstContenido = new List<contenido_ingreso_paso>();
        }

        private static List<ingresos_x_paso> mapeo(SqlDataReader dr)
        {
            List<ingresos_x_paso> lst = new List<ingresos_x_paso>();
            ingresos_x_paso obj;
            if (dr.HasRows)
            {
                int ID = dr.GetOrdinal("id");
                int ID_PASO = dr.GetOrdinal("id_paso");
                int TITULO = dr.GetOrdinal("titulo");
                int SUBTITULO = dr.GetOrdinal("subtitulo");
                int ORDEN = dr.GetOrdinal("orden");
                int ACTIVO = dr.GetOrdinal("activo");

                while (dr.Read())
                {
                    obj = new ingresos_x_paso();
                    if (!dr.IsDBNull(ID)) { obj.id = dr.GetInt32(ID); }
                    if (!dr.IsDBNull(ID_PASO)) { obj.id_paso = dr.GetInt32(ID_PASO); }
                    if (!dr.IsDBNull(TITULO)) { obj.titulo = dr.GetString(TITULO); }
                    if (!dr.IsDBNull(SUBTITULO)) { obj.subtitulo = dr.GetString(SUBTITULO); }
                    if (!dr.IsDBNull(ORDEN)) { obj.orden = dr.GetInt32(ORDEN); }
                    if (!dr.IsDBNull(ACTIVO)) { obj.activo = dr.GetBoolean(ACTIVO); }
                    obj.lstContenido = contenido_ingreso_paso.read(obj.id);
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<ingresos_x_paso> read(int idPaso)
        {
            try
            {
                List<ingresos_x_paso> lst = new List<ingresos_x_paso>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM ingresos_x_paso WHERE id_paso=@id_paso";
                    cmd.Parameters.AddWithValue("@id_paso", idPaso);
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

        public static ingresos_x_paso getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM ingresos_x_paso WHERE");
                sql.AppendLine("id = @id");
                ingresos_x_paso obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ingresos_x_paso> lst = mapeo(dr);
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
        public static int maxOrden(int idPaso)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                ingresos_x_paso obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT ISNULL(MAX(ORDEN), 0)
                                        FROM INGRESOS_X_PASO
                                        WHERE ID_PASO = @ID_PASO";
                    cmd.Parameters.AddWithValue("@ID_PASO", idPaso);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string getNombreByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT titulo FROM ingresos_x_paso WHERE");
                sql.AppendLine("id = @id");
                string nombre = string.Empty;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int TITULO = dr.GetOrdinal("titulo");

                        while (dr.Read())
                        {
                            if (!dr.IsDBNull(TITULO)) { nombre = dr.GetString(TITULO); }
                        }
                    }
                }
                return nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int insert(ingreso_paso_model obj)
        {
            try
            {
                int orden = maxOrden(obj.id_paso) + 1;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO ingresos_x_paso(");
                sql.AppendLine("id_paso");
                sql.AppendLine(", titulo");
                sql.AppendLine(", orden");
                sql.AppendLine(", activo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_paso");
                sql.AppendLine(", @titulo");
                sql.AppendLine(", @orden");
                sql.AppendLine(", 1");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_paso", obj.id_paso);
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("@orden", orden);

                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(ingreso_paso_model obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  ingresos_x_paso SET");
                sql.AppendLine("titulo=@titulo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(ingresos_x_paso obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  ingresos_x_paso ");
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

