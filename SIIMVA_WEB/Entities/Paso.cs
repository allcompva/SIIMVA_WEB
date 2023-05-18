using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Paso : DALBase
    {
        public int id { get; set; }
        public int id_tramite { get; set; }
        public int id_oficina { get; set; }
        public int id_direccion { get; set; }
        public int id_secretaria { get; set; }
        public bool en_usuario { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int orden { get; set; }
        public bool activo { get; set; }
        public bool es_final { get; set; }
        public int proxima_oficina { get; set; }
        public int proxima_oficina_rechazo { get; set; }
        public List<ingresos_x_paso> lstIngresos { get; set; }
        public string nombre_unidad_organizativa { get; set; }
        public string logo_unidad_administrativa { get; set; }
        public string nombre_tramite { get; set; }
        public string nombre_proxima_oficina { get; set; }
        public Paso()
        {
            id = 0;
            id_tramite = 0;
            id_oficina = 0;
            id_direccion = 0;
            id_secretaria = 0;
            en_usuario = false;
            nombre = string.Empty;
            descripcion = string.Empty;
            orden = 0;
            activo = false;
            nombre_unidad_organizativa = string.Empty;
            logo_unidad_administrativa = string.Empty;
            nombre_tramite = string.Empty;
            es_final = false;
            proxima_oficina = 0;
            proxima_oficina_rechazo = 0;
        }
        private static List<Paso> mapeoSimple(SqlDataReader dr)
        {
            List<Paso> lst = new List<Paso>();
            Paso obj;
            if (dr.HasRows)
            {
                int ID = dr.GetOrdinal("id");
                int ID_TRAMITE = dr.GetOrdinal("id_tramite");
                int ID_OFICINA = dr.GetOrdinal("id_oficina");
                int ID_DIRECCION = dr.GetOrdinal("id_direccion");
                int ID_SECRETARIA = dr.GetOrdinal("id_secretaria");
                int EN_USUARIO = dr.GetOrdinal("en_usuario");
                int NOMBRE = dr.GetOrdinal("nombre");
                int DESCRIPCION = dr.GetOrdinal("descripcion");
                int ORDEN = dr.GetOrdinal("orden");
                int ACTIVO = dr.GetOrdinal("activo");
                int es_final = dr.GetOrdinal("es_final");
                int proxima_oficina = dr.GetOrdinal("proxima_oficina");
                int proxima_oficina_rechazo = dr.GetOrdinal("proxima_oficina_rechazo");
                int nombre_proxima_oficina = dr.GetOrdinal("nombre_proxima_oficina");
                int nombre_unidad_organizativa = dr.GetOrdinal("nombre_unidad_organizativa");

                while (dr.Read())
                {
                    obj = new Paso();
                    if (!dr.IsDBNull(ID)) { obj.id = dr.GetInt32(ID); }
                    if (!dr.IsDBNull(ID_TRAMITE)) { obj.id_tramite = dr.GetInt32(ID_TRAMITE); }
                    if (!dr.IsDBNull(ID_OFICINA)) { obj.id_oficina = dr.GetInt32(ID_OFICINA); }
                    if (!dr.IsDBNull(ID_DIRECCION)) { obj.id_direccion = dr.GetInt32(ID_DIRECCION); }
                    if (!dr.IsDBNull(ID_SECRETARIA)) { obj.id_secretaria = dr.GetInt32(ID_SECRETARIA); }
                    if (!dr.IsDBNull(EN_USUARIO)) { obj.en_usuario = dr.GetBoolean(EN_USUARIO); }
                    if (!dr.IsDBNull(NOMBRE)) { obj.nombre = dr.GetString(NOMBRE); }
                    if (!dr.IsDBNull(DESCRIPCION)) { obj.descripcion = dr.GetString(DESCRIPCION); }
                    if (!dr.IsDBNull(ORDEN)) { obj.orden = dr.GetInt32(ORDEN); }
                    if (!dr.IsDBNull(ACTIVO)) { obj.activo = dr.GetBoolean(ACTIVO); }
                    if (!dr.IsDBNull(es_final)) { obj.es_final = dr.GetBoolean(es_final); }
                    if (!dr.IsDBNull(proxima_oficina)) { obj.proxima_oficina = dr.GetInt32(proxima_oficina); }
                    if (!dr.IsDBNull(proxima_oficina_rechazo)) { obj.proxima_oficina_rechazo = dr.GetInt32(proxima_oficina_rechazo); }
                    if (!dr.IsDBNull(nombre_proxima_oficina)) { obj.nombre_proxima_oficina = dr.GetString(nombre_proxima_oficina); }
                    if (!dr.IsDBNull(nombre_unidad_organizativa)) { obj.nombre_unidad_organizativa = dr.GetString(nombre_unidad_organizativa); }

                    lst.Add(obj);
                }
            }
            return lst;
        }
        private static List<Paso> mapeo(SqlDataReader dr)
        {
            List<Paso> lst = new List<Paso>();
            Paso obj;
            if (dr.HasRows)
            {
                int ID = dr.GetOrdinal("id");
                int ID_TRAMITE = dr.GetOrdinal("id_tramite");
                int ID_OFICINA = dr.GetOrdinal("id_oficina");
                int ID_DIRECCION = dr.GetOrdinal("id_direccion");
                int ID_SECRETARIA = dr.GetOrdinal("id_secretaria");
                int EN_USUARIO = dr.GetOrdinal("en_usuario");
                int NOMBRE = dr.GetOrdinal("nombre");
                int DESCRIPCION = dr.GetOrdinal("descripcion");
                int ORDEN = dr.GetOrdinal("orden");
                int ACTIVO = dr.GetOrdinal("activo");
                int es_final = dr.GetOrdinal("es_final");
                int nombre_unidad_organizativa = dr.GetOrdinal("nombre_unidad_organizativa");
                int logo_unidad_administrativa = dr.GetOrdinal("logo_unidad_administrativa");
                int nombre_tramite = dr.GetOrdinal("nombre_tramite");
                int proxima_oficina = dr.GetOrdinal("proxima_oficina");
                int proxima_oficina_rechazo = dr.GetOrdinal("proxima_oficina_rechazo");

                while (dr.Read())
                {
                    obj = new Paso();
                    if (!dr.IsDBNull(ID)) { obj.id = dr.GetInt32(ID); }
                    if (!dr.IsDBNull(ID_TRAMITE)) { obj.id_tramite = dr.GetInt32(ID_TRAMITE); }
                    if (!dr.IsDBNull(ID_OFICINA)) { obj.id_oficina = dr.GetInt32(ID_OFICINA); }
                    if (!dr.IsDBNull(ID_DIRECCION)) { obj.id_direccion = dr.GetInt32(ID_DIRECCION); }
                    if (!dr.IsDBNull(ID_SECRETARIA)) { obj.id_secretaria = dr.GetInt32(ID_SECRETARIA); }
                    if (!dr.IsDBNull(EN_USUARIO)) { obj.en_usuario = dr.GetBoolean(EN_USUARIO); }
                    if (!dr.IsDBNull(NOMBRE)) { obj.nombre = dr.GetString(NOMBRE); }
                    if (!dr.IsDBNull(DESCRIPCION)) { obj.descripcion = dr.GetString(DESCRIPCION); }
                    if (!dr.IsDBNull(ORDEN)) { obj.orden = dr.GetInt32(ORDEN); }
                    if (!dr.IsDBNull(ACTIVO)) { obj.activo = dr.GetBoolean(ACTIVO); }
                    if (!dr.IsDBNull(es_final)) { obj.es_final = dr.GetBoolean(es_final); }
                    if (!dr.IsDBNull(proxima_oficina)) { obj.proxima_oficina = dr.GetInt32(proxima_oficina); }
                    if (!dr.IsDBNull(proxima_oficina_rechazo)) { obj.proxima_oficina_rechazo = dr.GetInt32(proxima_oficina_rechazo); }

                    if (!dr.IsDBNull(nombre_unidad_organizativa)) { obj.nombre_unidad_organizativa = dr.GetString(nombre_unidad_organizativa); }
                    if (!dr.IsDBNull(logo_unidad_administrativa)) { obj.logo_unidad_administrativa = dr.GetString(logo_unidad_administrativa); }
                    if (!dr.IsDBNull(nombre_tramite)) { obj.nombre_tramite = dr.GetString(nombre_tramite); }

                    obj.lstIngresos = Entities.ingresos_x_paso.read(obj.id);
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Paso> read(int idTramite)
        {
            try
            {
                List<Paso> lst = new List<Paso>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT A.*, D.nombre_oficina AS nombre_unidad_organizativa, 
                                      B.logo_unidad_administrativa,
                                      B.NOMBRE AS nombre_tramite
                                      FROM PASO A
                                      INNER JOIN TRAMITE B ON A.ID_TRAMITE=B.ID 
                                      LEFT JOIN SIIMVA.dbo.OFICINAS D ON 
                                      A.id_oficina = D.codigo_oficina
                                      WHERE id_tramite=@id_tramite";
                    cmd.Parameters.AddWithValue("@id_tramite", idTramite);
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
        public static List<Paso> readBackEnd(int idTramite)
        {
            try
            {
                List<Paso> lst = new List<Paso>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT A.*, ISNULL(B.nombre_oficina, 'VECINO') AS nombre_unidad_organizativa,
                                        ISNULL(C.nombre_oficina, 'VECINO') AS nombre_proxima_oficina
                                        FROM PASO A
                                        LEFT JOIN SIIMVA.dbo.OFICINAS B ON A.ID_OFICINA=B.codigo_oficina
                                        LEFT JOIN SIIMVA.dbo.OFICINAS C ON A.proxima_oficina=C.codigo_oficina
                                        WHERE ID_TRAMITE=@id_tramite";
                    cmd.Parameters.AddWithValue("@id_tramite", idTramite);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeoSimple(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Paso getByPk(
        int ID)
        {
            try
            {
                Paso obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT A.*, 
                                        B.nombre_unidad_organizativa,
                                        B.logo_unidad_administrativa,
                                        B.NOMBRE AS nombre_tramite
                                        FROM PASO A
                                        INNER JOIN TRAMITE B ON A.ID_TRAMITE=B.ID
                                        WHERE A.ID=@ID";
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Entities.Paso> lst = mapeo(dr);
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
        public static Paso getProximo(
                int id_tramite, int paso_actual)
        {
            try
            {
                Paso obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        @"SELECT TOP 1 A.*, 
                          B.nombre_unidad_organizativa,
                          B.logo_unidad_administrativa,
                          B.NOMBRE AS nombre_tramite
                          FROM PASO A
                          INNER JOIN TRAMITE B ON A.ID_TRAMITE=B.ID
                          WHERE ID_TRAMITE = @ID_TRAMITE AND ORDEN >
                          (SELECT ORDEN FROM PASO
                          WHERE ID=@paso_actual)
                          ORDER BY ORDEN  ASC";
                    cmd.Parameters.AddWithValue("@ID_TRAMITE", id_tramite);
                    cmd.Parameters.AddWithValue("@paso_actual", paso_actual);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Entities.Paso> lst = mapeo(dr);
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
        public static int insert(PasoModel obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Paso(");
                sql.AppendLine("id_tramite");
                if(obj.id_oficina != 0)
                    sql.AppendLine(", id_oficina");
                else
                    sql.AppendLine(", en_usuario");
                sql.AppendLine(", nombre");
                sql.AppendLine(", orden");
                sql.AppendLine(", activo");
                if(obj.es_final)
                    sql.AppendLine(", es_final");
                else
                    sql.AppendLine(", proxima_oficina");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_tramite");
                if (obj.id_oficina != 0)
                    sql.AppendLine(", @id_oficina");
                else
                    sql.AppendLine(", @en_usuario");
                sql.AppendLine(", @nombre");
                sql.AppendLine(", @orden");
                sql.AppendLine(", @activo");
                if (obj.es_final)
                    sql.AppendLine(", @es_final");
                else
                    sql.AppendLine(", @proxima_oficina");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tramite", obj.id_tramite);
                    if (obj.id_oficina != 0)
                        cmd.Parameters.AddWithValue("@id_oficina", obj.id_oficina);
                    else
                        cmd.Parameters.AddWithValue("@en_usuario", obj.en_usuario);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@activo", 1);
                    if (obj.es_final)
                        cmd.Parameters.AddWithValue("@es_final", obj.es_final);
                    else
                        cmd.Parameters.AddWithValue("@proxima_oficina", obj.proxima_oficina);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(PasoModel obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Paso SET");
                sql.AppendLine(", id_oficina=@id_oficina");
                sql.AppendLine(", en_usuario=@en_usuario");
                sql.AppendLine(", nombre=@nombre");
                sql.AppendLine(", es_final=@es_final");
                sql.AppendLine(", proxima_oficina=@proxima_oficina");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_oficina", obj.id_oficina);
                    cmd.Parameters.AddWithValue("@en_usuario", obj.en_usuario);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@es_final", obj.es_final);
                    cmd.Parameters.AddWithValue("@proxima_oficina", obj.proxima_oficina);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Paso obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Paso ");
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

