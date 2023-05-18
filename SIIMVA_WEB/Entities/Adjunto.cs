using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Adjunto : DALBase
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string etiqueta { get; set; }
        public string link { get; set; }
        public int orden { get; set; }
        public bool requerido { get; set; }
        public bool activo { get; set; }
        public int id_contenido_ingreso_paso { get; set; }
        public string ingreso_usuario { get; set; }
        public string extenciones_aceptadas { get; set; }
        public bool multiple { get; set; }

        public Adjunto()
        {
            id = 0;
            nombre = string.Empty;
            descripcion = string.Empty;
            etiqueta = string.Empty;
            link = string.Empty;
            orden = 0;
            requerido = false;
            activo = false;
            id_contenido_ingreso_paso = 0;
            ingreso_usuario = string.Empty;
            extenciones_aceptadas = string.Empty;
            multiple = false;
        }

        private static List<Adjunto> mapeo(SqlDataReader dr)
        {
            List<Adjunto> lst = new List<Adjunto>();
            Adjunto obj;
            if (dr.HasRows)
            {
                int ID = dr.GetOrdinal("id");
                int NOMBRE = dr.GetOrdinal("nombre");
                int DESCRIPCION = dr.GetOrdinal("descripcion");
                int ETIQUETA = dr.GetOrdinal("etiqueta");
                int LINK = dr.GetOrdinal("link");
                int ORDEN = dr.GetOrdinal("orden");
                int REQUERIDO = dr.GetOrdinal("requerido");
                int ACTIVO = dr.GetOrdinal("activo");
                int ID_CONTENIDO_INGRESO_PASO = dr.GetOrdinal("id_contenido_ingreso_paso");
                int extenciones_aceptadas = dr.GetOrdinal("extenciones_aceptadas");
                int multiple = dr.GetOrdinal("multiple");

                while (dr.Read())
                {
                    obj = new Adjunto();
                    if (!dr.IsDBNull(ID)) { obj.id = dr.GetInt32(ID); }
                    if (!dr.IsDBNull(NOMBRE)) { obj.nombre = dr.GetString(NOMBRE); }
                    if (!dr.IsDBNull(DESCRIPCION)) { obj.descripcion = dr.GetString(DESCRIPCION); }
                    if (!dr.IsDBNull(ETIQUETA)) { obj.etiqueta = dr.GetString(ETIQUETA); }
                    if (!dr.IsDBNull(LINK)) { obj.link = dr.GetString(LINK); }
                    if (!dr.IsDBNull(ORDEN)) { obj.orden = dr.GetInt32(ORDEN); }
                    if (!dr.IsDBNull(REQUERIDO)) { obj.requerido = dr.GetBoolean(REQUERIDO); }
                    if (!dr.IsDBNull(ACTIVO)) { obj.activo = dr.GetBoolean(ACTIVO); }
                    if (!dr.IsDBNull(ID_CONTENIDO_INGRESO_PASO)) { obj.id_contenido_ingreso_paso = dr.GetInt32(ID_CONTENIDO_INGRESO_PASO); }

                    if (!dr.IsDBNull(extenciones_aceptadas)) { obj.extenciones_aceptadas = dr.GetString(extenciones_aceptadas); }
                    if (!dr.IsDBNull(multiple)) { obj.multiple = dr.GetBoolean(multiple); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Adjunto> read()
        {
            try
            {
                List<Adjunto> lst = new List<Adjunto>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Adjunto";
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

        public static Adjunto getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Adjunto WHERE");
                sql.AppendLine("id = @id");
                Adjunto obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Adjunto> lst = mapeo(dr);
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

        public static int insert(Adjunto obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Adjunto(");
                sql.AppendLine("nombre");
                sql.AppendLine(", descripcion");
                sql.AppendLine(", etiqueta");
                sql.AppendLine(", link");
                sql.AppendLine(", orden");
                sql.AppendLine(", requerido");
                sql.AppendLine(", activo");
                sql.AppendLine(", id_contenido_ingreso_paso");
                sql.AppendLine(", extenciones_aceptadas");
                sql.AppendLine(", multiple");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nombre");
                sql.AppendLine(", @descripcion");
                sql.AppendLine(", @etiqueta");
                sql.AppendLine(", @link");
                sql.AppendLine(", @orden");
                sql.AppendLine(", @requerido");
                sql.AppendLine(", @activo");
                sql.AppendLine(", @id_contenido_ingreso_paso");
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
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@etiqueta", obj.etiqueta);
                    cmd.Parameters.AddWithValue("@link", obj.link);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@requerido", obj.requerido);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@id_contenido_ingreso_paso", obj.id_contenido_ingreso_paso);
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

        public static void update(Adjunto obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Adjunto SET");
                sql.AppendLine("nombre=@nombre");
                sql.AppendLine(", descripcion=@descripcion");
                sql.AppendLine(", etiqueta=@etiqueta");
                sql.AppendLine(", link=@link");
                sql.AppendLine(", orden=@orden");
                sql.AppendLine(", requerido=@requerido");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine(", extenciones_aceptadas=@extenciones_aceptadas");
                sql.AppendLine(", multiple=@multiple");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("@etiqueta", obj.etiqueta);
                    cmd.Parameters.AddWithValue("@link", obj.link);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@requerido", obj.requerido);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@extenciones_aceptadas", obj.extenciones_aceptadas);
                    cmd.Parameters.AddWithValue("@multiple", obj.multiple);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Adjunto obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Adjunto ");
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

