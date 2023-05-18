using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Tramite : DALBase
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_crea { get; set; }
        public string usu_crea { get; set; }
        public DateTime fecha_modifica { get; set; }
        public string usu_modifica { get; set; }
        public bool activo { get; set; }
        public DateTime fecha_baja { get; set; }
        public string usu_baja { get; set; }
        public int id_unidad_organizativa { get; set; }
        public string nombre_unidad_organizativa { get; set; }  
        public string logo_unidad_administrativa { get; set; }  
        public int primer_paso { get; set; }
        public List<Paso> lstPasos { get; set; }
        public Tramite()
        {
            id = 0;
            nombre = string.Empty;
            descripcion = string.Empty;
            fecha_crea = DateTime.Now;
            usu_crea = string.Empty;
            fecha_modifica = DateTime.Now;
            usu_modifica = string.Empty;
            activo = false;
            fecha_baja = DateTime.Now;
            usu_baja = string.Empty;
            id_unidad_organizativa = 0;
            nombre_unidad_organizativa = string.Empty;
            logo_unidad_administrativa = string.Empty;
            primer_paso = 0;
            lstPasos = new List<Paso>();    
        }
        private static List<Tramite> mapeo(SqlDataReader dr)
        {
            List<Tramite> lst = new List<Tramite>();
            Tramite obj;
            if (dr.HasRows)
            {
                int ID = dr.GetOrdinal("id");
                int NOMBRE = dr.GetOrdinal("nombre");
                int DESCRIPCION = dr.GetOrdinal("descripcion");
                int FECHA_CREA = dr.GetOrdinal("fecha_crea");
                int USU_CREA = dr.GetOrdinal("usu_crea");
                int FECHA_MODIFICA = dr.GetOrdinal("fecha_modifica");
                int USU_MODIFICA = dr.GetOrdinal("usu_modifica");
                int ACTIVO = dr.GetOrdinal("activo");
                int FECHA_BAJA = dr.GetOrdinal("fecha_baja");
                int USU_BAJA = dr.GetOrdinal("usu_baja");
                int ID_UNIDAD_ORGANIZATIVA = dr.GetOrdinal("ID_UNIDAD_ORGANIZATIVA");
                int nombre_unidad_organizativa = dr.GetOrdinal("nombre_unidad_organizativa");
                int logo_unidad_administrativa = dr.GetOrdinal("logo_unidad_administrativa");
                while (dr.Read())
                {
                    obj = new Tramite();
                    if (!dr.IsDBNull(ID)) { obj.id = dr.GetInt32(ID); }
                    if (!dr.IsDBNull(NOMBRE)) { obj.nombre = dr.GetString(NOMBRE); }
                    if (!dr.IsDBNull(DESCRIPCION)) { obj.descripcion = dr.GetString(DESCRIPCION); }
                    if (!dr.IsDBNull(FECHA_CREA)) { obj.fecha_crea = dr.GetDateTime(FECHA_CREA); }
                    if (!dr.IsDBNull(USU_CREA)) { obj.usu_crea = dr.GetString(USU_CREA); }
                    if (!dr.IsDBNull(FECHA_MODIFICA)) { obj.fecha_modifica = dr.GetDateTime(FECHA_MODIFICA); }
                    if (!dr.IsDBNull(USU_MODIFICA)) { obj.usu_modifica = dr.GetString(USU_MODIFICA); }
                    if (!dr.IsDBNull(ACTIVO)) { obj.activo = dr.GetBoolean(ACTIVO); }
                    if (!dr.IsDBNull(FECHA_BAJA)) { obj.fecha_baja = dr.GetDateTime(FECHA_BAJA); }
                    if (!dr.IsDBNull(USU_BAJA)) { obj.usu_baja = dr.GetString(USU_BAJA); }
                    if (!dr.IsDBNull(ID_UNIDAD_ORGANIZATIVA)) { obj.id_unidad_organizativa = dr.GetInt32(ID_UNIDAD_ORGANIZATIVA); }
                    if (!dr.IsDBNull(nombre_unidad_organizativa)) { obj.nombre_unidad_organizativa = dr.GetString(nombre_unidad_organizativa); }
                    if (!dr.IsDBNull(logo_unidad_administrativa)) { obj.logo_unidad_administrativa = dr.GetString(logo_unidad_administrativa); }

                    lst.Add(obj);
                }
            }
            return lst;
        }
        private static List<Tramite> mapeoCompleto(SqlDataReader dr)
        {
            List<Tramite> lst = new List<Tramite>();
            Tramite obj;
            if (dr.HasRows)
            {
                int ID = dr.GetOrdinal("id");
                int NOMBRE = dr.GetOrdinal("nombre");
                int DESCRIPCION = dr.GetOrdinal("descripcion");
                int FECHA_CREA = dr.GetOrdinal("fecha_crea");
                int USU_CREA = dr.GetOrdinal("usu_crea");
                int FECHA_MODIFICA = dr.GetOrdinal("fecha_modifica");
                int USU_MODIFICA = dr.GetOrdinal("usu_modifica");
                int ACTIVO = dr.GetOrdinal("activo");
                int FECHA_BAJA = dr.GetOrdinal("fecha_baja");
                int USU_BAJA = dr.GetOrdinal("usu_baja");
                int ID_UNIDAD_ORGANIZATIVA = dr.GetOrdinal("ID_UNIDAD_ORGANIZATIVA");
                int nombre_unidad_organizativa = dr.GetOrdinal("nombre_unidad_organizativa");
                int logo_unidad_administrativa = dr.GetOrdinal("logo_unidad_administrativa");
                while (dr.Read())
                {
                    obj = new Tramite();
                    if (!dr.IsDBNull(ID)) { obj.id = dr.GetInt32(ID); }
                    if (!dr.IsDBNull(NOMBRE)) { obj.nombre = dr.GetString(NOMBRE); }
                    if (!dr.IsDBNull(DESCRIPCION)) { obj.descripcion = dr.GetString(DESCRIPCION); }
                    if (!dr.IsDBNull(FECHA_CREA)) { obj.fecha_crea = dr.GetDateTime(FECHA_CREA); }
                    if (!dr.IsDBNull(USU_CREA)) { obj.usu_crea = dr.GetString(USU_CREA); }
                    if (!dr.IsDBNull(FECHA_MODIFICA)) { obj.fecha_modifica = dr.GetDateTime(FECHA_MODIFICA); }
                    if (!dr.IsDBNull(USU_MODIFICA)) { obj.usu_modifica = dr.GetString(USU_MODIFICA); }
                    if (!dr.IsDBNull(ACTIVO)) { obj.activo = dr.GetBoolean(ACTIVO); }
                    if (!dr.IsDBNull(FECHA_BAJA)) { obj.fecha_baja = dr.GetDateTime(FECHA_BAJA); }
                    if (!dr.IsDBNull(USU_BAJA)) { obj.usu_baja = dr.GetString(USU_BAJA); }
                    if (!dr.IsDBNull(ID_UNIDAD_ORGANIZATIVA)) { obj.id_unidad_organizativa = dr.GetInt32(ID_UNIDAD_ORGANIZATIVA); }
                    if (!dr.IsDBNull(nombre_unidad_organizativa)) { obj.nombre_unidad_organizativa = dr.GetString(nombre_unidad_organizativa); }
                    if (!dr.IsDBNull(logo_unidad_administrativa)) { obj.logo_unidad_administrativa = dr.GetString(logo_unidad_administrativa); }
                    obj.lstPasos = Paso.read(obj.id);
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Tramite> read()
        {
            try
            {
                List<Tramite> lst = new List<Tramite>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT A.*,
                                        (SELECT TOP 1 ID FROM PASO B WHERE ID_TRAMITE = A.ID 
                                        ORDER BY B.ORDEN ASC)
                                        AS primer_paso
                                        FROM TRAMITE A";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Tramite obj;
                    if (dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("id");
                        int NOMBRE = dr.GetOrdinal("nombre");
                        int DESCRIPCION = dr.GetOrdinal("descripcion");
                        int FECHA_CREA = dr.GetOrdinal("fecha_crea");
                        int USU_CREA = dr.GetOrdinal("usu_crea");
                        int FECHA_MODIFICA = dr.GetOrdinal("fecha_modifica");
                        int USU_MODIFICA = dr.GetOrdinal("usu_modifica");
                        int ACTIVO = dr.GetOrdinal("activo");
                        int FECHA_BAJA = dr.GetOrdinal("fecha_baja");
                        int USU_BAJA = dr.GetOrdinal("usu_baja");
                        int ID_UNIDAD_ORGANIZATIVA = dr.GetOrdinal("id_unidad_organizativa");
                        int nombre_unidad_organizativa = dr.GetOrdinal("nombre_unidad_organizativa");
                        int logo_unidad_administrativa = dr.GetOrdinal("logo_unidad_administrativa");
                        int primer_paso = dr.GetOrdinal("primer_paso");

                        while (dr.Read())
                        {
                            obj = new Tramite();
                            if (!dr.IsDBNull(ID)) { obj.id = dr.GetInt32(ID); }
                            if (!dr.IsDBNull(NOMBRE)) { obj.nombre = dr.GetString(NOMBRE); }
                            if (!dr.IsDBNull(DESCRIPCION)) { obj.descripcion = dr.GetString(DESCRIPCION); }
                            if (!dr.IsDBNull(FECHA_CREA)) { obj.fecha_crea = dr.GetDateTime(FECHA_CREA); }
                            if (!dr.IsDBNull(USU_CREA)) { obj.usu_crea = dr.GetString(USU_CREA); }
                            if (!dr.IsDBNull(FECHA_MODIFICA)) { obj.fecha_modifica = dr.GetDateTime(FECHA_MODIFICA); }
                            if (!dr.IsDBNull(USU_MODIFICA)) { obj.usu_modifica = dr.GetString(USU_MODIFICA); }
                            if (!dr.IsDBNull(ACTIVO)) { obj.activo = dr.GetBoolean(ACTIVO); }
                            if (!dr.IsDBNull(FECHA_BAJA)) { obj.fecha_baja = dr.GetDateTime(FECHA_BAJA); }
                            if (!dr.IsDBNull(USU_BAJA)) { obj.usu_baja = dr.GetString(USU_BAJA); }
                            if (!dr.IsDBNull(ID_UNIDAD_ORGANIZATIVA)) { obj.id_unidad_organizativa = dr.GetInt32(ID_UNIDAD_ORGANIZATIVA); }
                            if (!dr.IsDBNull(nombre_unidad_organizativa)) { obj.nombre_unidad_organizativa = dr.GetString(nombre_unidad_organizativa); }
                            if (!dr.IsDBNull(logo_unidad_administrativa)) { obj.logo_unidad_administrativa = dr.GetString(logo_unidad_administrativa); }
                            if (!dr.IsDBNull(primer_paso)) { obj.primer_paso = dr.GetInt32(primer_paso); }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Tramite getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Tramite WHERE");
                sql.AppendLine("id = @id");
                Tramite obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Tramite> lst = mapeoCompleto(dr);
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

        public static int insert(Tramite obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Tramite(");
                sql.AppendLine("nombre");
                sql.AppendLine(", fecha_crea");
                sql.AppendLine(", usu_crea");
                sql.AppendLine(", activo");
                sql.AppendLine(", id_unidad_organizativa");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nombre");
                sql.AppendLine(", GETDATE()");
                sql.AppendLine(", @usu_crea");
                sql.AppendLine(", 1");
                sql.AppendLine(", @id_unidad_organizativa");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@usu_crea", obj.usu_crea);
                    cmd.Parameters.AddWithValue("@id_unidad_organizativa", obj.id_unidad_organizativa);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Tramite obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Tramite SET");
                sql.AppendLine("nombre=@nombre");
                sql.AppendLine(", fecha_modifica=GETDATE()");
                sql.AppendLine(", usu_modifica=@usu_modifica");
                sql.AppendLine(", id_unidad_organizativa=@id_unidad_organizativa"); 
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@usu_modifica", obj.usu_modifica);
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@id_unidad_organizativa", obj.id_unidad_organizativa);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Tramite obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Tramite ");
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

