using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Tramites : DALBase
    {
        public int id { get; set; }
        public int id_tramite { get; set; }
        public string cuit { get; set; }
        public string cuit_representado { get; set; }
        public DateTime fecha { get; set; }
        public int paso_anterior { get; set; }
        public int paso_actual { get; set; }
        public List<Pasos> lstPasos { get; set; }
        public int anio { get; set; }
        public int nro_expediente { get; set; }
        public string nombre_oficina { get; set; }
        public string nombre_tramite { get; set; }
        public string logo_oficina { get; set; }
        public decimal avance { get; set; }
        public string nombre_contribuyente { get; set; }
        public string avatar { get; set; }
        public int id_oficina { get; set; }
        public int estado { get; set; }
        public int en_vecino { get; set; }  
        public string _estado { get; set; }
        public Tramites()
        {
            id = 0;
            id_tramite = 0;
            cuit = string.Empty;
            cuit_representado = string.Empty;
            fecha = DateTime.Now;
            paso_anterior = 0;
            paso_actual = 0;
            anio = 0;
            nro_expediente = 0; 
            logo_oficina = string.Empty;
            nombre_oficina = string.Empty;
            nombre_tramite = string.Empty;
            lstPasos = new List<Pasos>();
            avance = 0;
            nombre_contribuyente=string.Empty;
            avatar = string.Empty;
            id_oficina = 0;
            estado = 0;
            en_vecino = 0;
            _estado = string.Empty;
        }

        private static List<Tramites> mapeo(SqlDataReader dr)
        {
            List<Tramites> lst = new List<Tramites>();
            Tramites obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int id_tramite = dr.GetOrdinal("id_tramite");
                int cuit = dr.GetOrdinal("cuit");
                int cuit_representado = dr.GetOrdinal("cuit_representado");
                int fecha = dr.GetOrdinal("fecha");
                int paso_anterior = dr.GetOrdinal("paso_anterior");
                int paso_actual = dr.GetOrdinal("paso_actual");
                int nro_expediente = dr.GetOrdinal("nro_expediente");
                int anio = dr.GetOrdinal("anio");
                int estado = dr.GetOrdinal("estado");
                int id_oficina = dr.GetOrdinal("id_oficina");
                int en_vecino = dr.GetOrdinal("en_vecino");
                int nombre_oficina = dr.GetOrdinal("nombre_unidad_organizativa");
                int nombre_tramite = dr.GetOrdinal("nombre_tramite");
                int nombre_contribuyente = dr.GetOrdinal("nombre_contribuyente");
                int logo_oficina = dr.GetOrdinal("logo_unidad_administrativa");

                int avatar = dr.GetOrdinal("avatar");
                int _estado = dr.GetOrdinal("_estado");

                while (dr.Read())
                {
                    obj = new Tramites();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(id_tramite)) { obj.id_tramite = dr.GetInt32(id_tramite); }
                    if (!dr.IsDBNull(cuit)) { obj.cuit = dr.GetString(cuit); }
                    if (!dr.IsDBNull(cuit_representado)) { obj.cuit_representado = dr.GetString(cuit_representado); }
                    if (!dr.IsDBNull(fecha)) { obj.fecha = dr.GetDateTime(fecha); }
                    if (!dr.IsDBNull(paso_anterior)) { obj.paso_anterior = dr.GetInt32(paso_anterior); }
                    if (!dr.IsDBNull(paso_actual)) { obj.paso_actual = dr.GetInt32(paso_actual); }
                    if (!dr.IsDBNull(nro_expediente)) { obj.paso_actual = dr.GetInt32(nro_expediente); }
                    if (!dr.IsDBNull(anio)) { obj.anio = dr.GetInt32(anio); }
                    if (!dr.IsDBNull(estado)) { obj.estado = dr.GetInt32(estado); }
                    if (!dr.IsDBNull(id_oficina)) { obj.id_oficina = dr.GetInt32(id_oficina); }
                    if (!dr.IsDBNull(en_vecino)) { obj.en_vecino = dr.GetInt32(en_vecino); }
                    if (!dr.IsDBNull(nombre_oficina)) { obj.nombre_oficina = dr.GetString(nombre_oficina); }
                    if (!dr.IsDBNull(nombre_tramite)) { obj.nombre_tramite = dr.GetString(nombre_tramite); }
                    if (!dr.IsDBNull(nombre_contribuyente)) { obj.nombre_contribuyente = dr.GetString(nombre_contribuyente); }
                    if (!dr.IsDBNull(logo_oficina)) { obj.logo_oficina = dr.GetString(logo_oficina); }
                    if (!dr.IsDBNull(avatar)) { obj.avatar = dr.GetString(avatar); }
                    if (!dr.IsDBNull(_estado)) { obj._estado = dr.GetString(_estado); }
                    
                    switch (obj.estado)
                    {
                        case 1:
                            obj.avance = 25;
                            break;
                        case 2:
                            obj.avance = 50;
                            break;
                        case 3:
                            obj.avance = 75;
                            break;
                        case 4:
                            obj.avance = 100;
                            break;
                        default:
                            break;
                    }
                    if(obj.estado == 5)
                        obj.estado = 1;

                    lst.Add(obj);
                }
            }
            return lst;
        }
        private static List<Tramites> mapeoCompleto(SqlDataReader dr)
        {
            List<Tramites> lst = new List<Tramites>();
            Tramites obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int id_tramite = dr.GetOrdinal("id_tramite");
                int cuit = dr.GetOrdinal("cuit");
                int cuit_representado = dr.GetOrdinal("cuit_representado");
                int fecha = dr.GetOrdinal("fecha");
                int paso_anterior = dr.GetOrdinal("paso_anterior");
                int paso_actual = dr.GetOrdinal("paso_actual");
                int nro_expediente = dr.GetOrdinal("nro_expediente");
                int anio = dr.GetOrdinal("anio");
                int estado = dr.GetOrdinal("estado");
                int id_oficina = dr.GetOrdinal("id_oficina");
                int en_vecino = dr.GetOrdinal("en_vecino");
                int nombre_oficina = dr.GetOrdinal("nombre_unidad_organizativa");
                int nombre_tramite = dr.GetOrdinal("nombre_tramite");
                int nombre_contribuyente = dr.GetOrdinal("nombre_contribuyente");
                int logo_oficina = dr.GetOrdinal("logo_unidad_administrativa");

                int avatar = dr.GetOrdinal("avatar");
                int _estado = dr.GetOrdinal("_estado");                

                while (dr.Read())
                {
                    obj = new Tramites();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(id_tramite)) { obj.id_tramite = dr.GetInt32(id_tramite); }
                    if (!dr.IsDBNull(cuit)) { obj.cuit = dr.GetString(cuit); }
                    if (!dr.IsDBNull(cuit_representado)) { obj.cuit_representado = dr.GetString(cuit_representado); }
                    if (!dr.IsDBNull(fecha)) { obj.fecha = dr.GetDateTime(fecha); }
                    if (!dr.IsDBNull(paso_anterior)) { obj.paso_anterior = dr.GetInt32(paso_anterior); }
                    if (!dr.IsDBNull(paso_actual)) { obj.paso_actual = dr.GetInt32(paso_actual); }
                    if (!dr.IsDBNull(nro_expediente)) { obj.nro_expediente = dr.GetInt32(nro_expediente); }
                    if (!dr.IsDBNull(anio)) { obj.anio = dr.GetInt32(anio); }
                    if (!dr.IsDBNull(estado)) { obj.estado = dr.GetInt32(estado); }
                    if (!dr.IsDBNull(id_oficina)) { obj.id_oficina = dr.GetInt32(id_oficina); }
                    if (!dr.IsDBNull(en_vecino)) { obj.en_vecino = dr.GetInt32(en_vecino); }
                    if (!dr.IsDBNull(nombre_oficina)) { obj.nombre_oficina = dr.GetString(nombre_oficina); }
                    if (!dr.IsDBNull(nombre_tramite)) { obj.nombre_tramite = dr.GetString(nombre_tramite); }
                    if (!dr.IsDBNull(nombre_contribuyente)) { obj.nombre_contribuyente = dr.GetString(nombre_contribuyente); }
                    if (!dr.IsDBNull(logo_oficina)) { obj.logo_oficina = dr.GetString(logo_oficina); }
                    if (!dr.IsDBNull(avatar)) { obj.avatar = dr.GetString(avatar); }
                    if (!dr.IsDBNull(_estado)) { obj._estado = dr.GetString(_estado); }
                    obj.avance = 50;

                    obj.lstPasos.AddRange(Pasos.read(obj.id));
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Tramites> read(string cuit)
        {
            try
            {
                List<Tramites> lst = new List<Tramites>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT A.*, 
                                        B.nombre_unidad_organizativa,
                                        B.NOMBRE as nombre_tramite,
                                        C.apellido + ', ' + C.NOMBRE as nombre_contribuyente, 
                                        B.logo_unidad_administrativa, A.avatar,
                                        _Estado = CASE estado
                                            WHEN 1 THEN 'INICIADO'
                                            WHEN 2 THEN 'EN PROCESO'
                                            WHEN 3 THEN 'CANCELADO'
                                            WHEN 4 THEN 'FINALIZADO'
                                        END
                                        FROM TRAMITES A
                                        INNER JOIN TRAMITE B ON A.id_tramite=B.ID
                                        INNER JOIN SIIMVA.dbo.VECINO_DIGITAL C ON 
                                        A.cuit COLLATE SQL_Latin1_General_CP1_CI_AS =
                                        C.CUIT COLLATE SQL_Latin1_General_CP1_CI_AS
                                        WHERE A.cuit = @cuit";
                    cmd.Parameters.AddWithValue("@cuit", cuit);
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
        public static List<Tramites> readOficina(int id_oficina)
        {
            try
            {
                List<Tramites> lst = new List<Tramites>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT A.*, 
                                        B.nombre_unidad_organizativa,
                                        B.NOMBRE as nombre_tramite,
                                        C.apellido + ', ' + C.NOMBRE as nombre_contribuyente, 
                                        B.logo_unidad_administrativa, A.avatar,
                                        _Estado = CASE estado
                                            WHEN 1 THEN 'INICIADO'
                                            WHEN 2 THEN 'EN PROCESO'
                                            WHEN 3 THEN 'CANCELADO'
                                            WHEN 4 THEN 'FINALIZADO'
                                        END
                                        FROM TRAMITES A
                                        INNER JOIN TRAMITE B ON A.id_tramite=B.ID
                                        INNER JOIN SIIMVA.dbo.VECINO_DIGITAL C ON 
                                        A.cuit COLLATE SQL_Latin1_General_CP1_CI_AS =
                                        C.CUIT COLLATE SQL_Latin1_General_CP1_CI_AS
                                        WHERE A.id_oficina = @id_oficina";
                    cmd.Parameters.AddWithValue("@id_oficina", id_oficina);
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

        public static List<Tramites> read()
        {
            try
            {
                List<Tramites> lst = new List<Tramites>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT A.*, 
                                        D.nombre_oficina AS nombre_unidad_organizativa,
                                        B.NOMBRE as nombre_tramite,
                                        C.apellido + ', ' + C.NOMBRE as nombre_contribuyente, 
                                        B.logo_unidad_administrativa, A.avatar,
                                        _Estado = CASE estado
                                            WHEN 1 THEN 'INICIADO'
                                            WHEN 2 THEN 'EN PROCESO'
                                            WHEN 3 THEN 'CANCELADO'
                                            WHEN 4 THEN 'FINALIZADO'
                                            WHEN 5 THEN 'CAMBIO OFICINA'
                                        END
                                        FROM TRAMITES A
                                        INNER JOIN TRAMITE B ON A.id_tramite=B.ID
                                        INNER JOIN SIIMVA.dbo.VECINO_DIGITAL C ON 
                                        A.cuit COLLATE SQL_Latin1_General_CP1_CI_AS =
                                        C.CUIT COLLATE SQL_Latin1_General_CP1_CI_AS
                                        LEFT JOIN SIIMVA.dbo.OFICINAS D ON 
                                        A.id_oficina = D.codigo_oficina";
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
        public static Tramites getByPk(
        int id)
        {
            try
            {
                Tramites obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT A.*, 
                                        B.nombre_unidad_organizativa,
                                        B.NOMBRE as nombre_tramite,
                                        C.apellido + ', ' + C.NOMBRE as nombre_contribuyente, 
                                        B.logo_unidad_administrativa, A.avatar,
                                        _Estado = CASE estado
                                            WHEN 1 THEN 'INICIADO'
                                            WHEN 2 THEN 'EN PROCESO'
                                            WHEN 3 THEN 'CANCELADO'
                                            WHEN 4 THEN 'FINALIZADO'
                                            WHEN 5 THEN 'CAMBIO OFICINA'
                                        END
                                        FROM TRAMITES A
                                        INNER JOIN TRAMITE B ON A.id_tramite=B.ID
                                        INNER JOIN SIIMVA.dbo.VECINO_DIGITAL C ON 
                                        A.cuit COLLATE SQL_Latin1_General_CP1_CI_AS =
                                        C.CUIT COLLATE SQL_Latin1_General_CP1_CI_AS
                                        LEFT JOIN SIIMVA.dbo.OFICINAS D ON 
                                        A.id_oficina = D.codigo_oficina
                                        WHERE A.id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Tramites> lst = mapeoCompleto(dr);
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

        public static int insert(Tramites obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Tramites(");
                sql.AppendLine("id_tramite");
                sql.AppendLine(", cuit");
                sql.AppendLine(", cuit_representado");
                sql.AppendLine(", fecha");
                sql.AppendLine(", paso_anterior");
                sql.AppendLine(", paso_actual");
                sql.AppendLine(", anio");
                sql.AppendLine(", nro_expediente");
                sql.AppendLine(", estado");
                sql.AppendLine(", id_oficina");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_tramite");
                sql.AppendLine(", @cuit");
                sql.AppendLine(", @cuit_representado");
                sql.AppendLine(", @fecha");
                sql.AppendLine(", @paso_anterior");
                sql.AppendLine(", @paso_actual");
                sql.AppendLine(", YEAR(GETDATE())");
                sql.AppendLine(", @nro_expediente");
                sql.AppendLine(", 1");
                sql.AppendLine(", @id_oficina");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tramite", obj.id_tramite);
                    cmd.Parameters.AddWithValue("@cuit", obj.cuit);
                    cmd.Parameters.AddWithValue("@cuit_representado", obj.cuit_representado);
                    cmd.Parameters.AddWithValue("@fecha", obj.fecha);
                    cmd.Parameters.AddWithValue("@paso_anterior", obj.paso_anterior);
                    cmd.Parameters.AddWithValue("@paso_actual", obj.paso_actual);
                    cmd.Parameters.AddWithValue("@nro_expediente", obj.nro_expediente);
                    cmd.Parameters.AddWithValue("@id_oficina", obj.id_oficina);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Tramites obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Tramites SET");
                sql.AppendLine("id_tramite=@id_tramite");
                sql.AppendLine(", cuit=@cuit");
                sql.AppendLine(", cuit_representado=@cuit_representado");
                sql.AppendLine(", fecha=@fecha");
                sql.AppendLine(", paso_anterior=@paso_anterior");
                sql.AppendLine(", paso_actual=@paso_actual");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tramite", obj.id_tramite);
                    cmd.Parameters.AddWithValue("@cuit", obj.cuit);
                    cmd.Parameters.AddWithValue("@cuit_representado", obj.cuit_representado);
                    cmd.Parameters.AddWithValue("@fecha", obj.fecha);
                    cmd.Parameters.AddWithValue("@paso_anterior", obj.paso_anterior);
                    cmd.Parameters.AddWithValue("@paso_actual", obj.paso_actual);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int recibir(int id_tramite, int paso_actual, 
            int id_tramites, int cod_usuario)
        {
            try
            {
                Paso objProximo = Paso.getProximo(id_tramite,
                    paso_actual);

                int control = 0;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Tramites SET");
                sql.AppendLine("paso_anterior=@paso_anterior");
                sql.AppendLine(", paso_actual=@paso_actual");
                sql.AppendLine(", estado=2");
                sql.AppendLine(", id_oficina=@id_oficina");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@paso_anterior", paso_actual);
                    cmd.Parameters.AddWithValue("@paso_actual", objProximo.id);
                    cmd.Parameters.AddWithValue("@id_oficina", objProximo.id_oficina);
                    cmd.Parameters.AddWithValue("@id", id_tramites);
                    cmd.Connection.Open();
                    control = Convert.ToInt32(cmd.ExecuteScalar());
                }
                Entities.Paso objPaso = Entities.Paso.getByPk(paso_actual);
                Movimiento_tramites objMov = new Movimiento_tramites();
                objMov.cod_usuario = cod_usuario;
                objMov.accion = "RECIBE";
                objMov.en_vecino = false;
                objMov.id_tramites = id_tramites;
                objMov.destino_vecino = false;
                objMov.id_oficina = objPaso.id_oficina;
                objMov.cod_oficina_destino = objPaso.proxima_oficina;
                Entities.Movimiento_tramites.insert(objMov);
                return objProximo.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void mover(int id_tramites, int paso_actual,
    int paso_anterior, int id_oficina)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Tramites SET");
                sql.AppendLine("paso_anterior=@paso_anterior");
                sql.AppendLine(", paso_actual=@paso_actual");
                sql.AppendLine(", estado=5");
                sql.AppendLine(", id_oficina=@id_oficina");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@paso_anterior", paso_anterior);
                    cmd.Parameters.AddWithValue("@paso_actual", paso_actual);
                    cmd.Parameters.AddWithValue("@id_oficina", id_oficina);
                    cmd.Parameters.AddWithValue("@id", id_tramites);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void finalizar_rechazar(int id_tramites, int estado)
        {
            try
            {
                int control = 0;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Tramites SET");
                sql.AppendLine("estado=@estado");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.Parameters.AddWithValue("@id", id_tramites);
                    cmd.Connection.Open();
                    control = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(Tramites obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Tramites ");
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

