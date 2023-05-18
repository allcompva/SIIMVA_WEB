using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Movimiento_tramites : DALBase
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public int id_tramites { get; set; }
        public int id_oficina { get; set; }
        public int id_direccion { get; set; }
        public int id_secretaria { get; set; }
        public bool en_vecino { get; set; }
        public string cuit { get; set; }
        public int cod_usuario { get; set; }
        public string accion { get; set; }
        public int cod_oficina_destino { get; set; }
        public bool destino_vecino { get; set; }

        public Movimiento_tramites()
        {
            id = 0;
            fecha = DateTime.Now;
            id_tramites = 0;
            id_oficina = 0;
            id_direccion = 0;
            id_secretaria = 0;
            en_vecino = false;
            cuit = string.Empty;
            cod_usuario = 0;
            accion = string.Empty;
            cod_oficina_destino = 0;
            destino_vecino = false;
        }

        private static List<Movimiento_tramites> mapeo(SqlDataReader dr)
        {
            List<Movimiento_tramites> lst = new List<Movimiento_tramites>();
            Movimiento_tramites obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int fecha = dr.GetOrdinal("fecha");
                int id_tramites = dr.GetOrdinal("id_tramites");
                int id_oficina = dr.GetOrdinal("id_oficina");
                int id_direccion = dr.GetOrdinal("id_direccion");
                int id_secretaria = dr.GetOrdinal("id_secretaria");
                int en_vecino = dr.GetOrdinal("en_vecino");
                int cuit = dr.GetOrdinal("cuit");
                int cod_usuario = dr.GetOrdinal("cod_usuario");
                int accion = dr.GetOrdinal("accion");
                int cod_oficina_destino = dr.GetOrdinal("cod_oficina_destino");
                int destino_vecino = dr.GetOrdinal("destino_vecino");
                while (dr.Read())
                {
                    obj = new Movimiento_tramites();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(fecha)) { obj.fecha = dr.GetDateTime(fecha); }
                    if (!dr.IsDBNull(id_tramites)) { obj.id_tramites = dr.GetInt32(id_tramites); }
                    if (!dr.IsDBNull(id_oficina)) { obj.id_oficina = dr.GetInt32(id_oficina); }
                    if (!dr.IsDBNull(id_direccion)) { obj.id_direccion = dr.GetInt32(id_direccion); }
                    if (!dr.IsDBNull(id_secretaria)) { obj.id_secretaria = dr.GetInt32(id_secretaria); }
                    if (!dr.IsDBNull(en_vecino)) { obj.en_vecino = dr.GetBoolean(en_vecino); }
                    if (!dr.IsDBNull(cuit)) { obj.cuit = dr.GetString(cuit); }
                    if (!dr.IsDBNull(cod_usuario)) { obj.cod_usuario = dr.GetInt32(cod_usuario); }
                    if (!dr.IsDBNull(accion)) { obj.accion = dr.GetString(accion); }
                    if (!dr.IsDBNull(cod_oficina_destino)) { obj.cod_oficina_destino = dr.GetInt32(cod_oficina_destino); }
                    if (!dr.IsDBNull(destino_vecino)) { obj.destino_vecino = dr.GetBoolean(destino_vecino); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Movimiento_tramites> read()
        {
            try
            {
                List<Movimiento_tramites> lst = new List<Movimiento_tramites>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Movimiento_tramites";
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

        public static Movimiento_tramites getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Movimiento_tramites WHERE");
                sql.AppendLine("id = @id");
                Movimiento_tramites obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Movimiento_tramites> lst = mapeo(dr);
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

        public static int insert(Movimiento_tramites obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Movimiento_tramites(");
                sql.AppendLine("fecha");
                sql.AppendLine(", id_tramites");
                sql.AppendLine(", id_oficina");
                sql.AppendLine(", id_direccion");
                sql.AppendLine(", id_secretaria");
                sql.AppendLine(", en_vecino");
                sql.AppendLine(", cuit");
                sql.AppendLine(", cod_usuario");
                sql.AppendLine(", accion");
                sql.AppendLine(", cod_oficina_destino");
                sql.AppendLine(", destino_vecino");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@fecha");
                sql.AppendLine(", @id_tramites");
                sql.AppendLine(", @id_oficina");
                sql.AppendLine(", @id_direccion");
                sql.AppendLine(", @id_secretaria");
                sql.AppendLine(", @en_vecino");
                sql.AppendLine(", @cuit");
                sql.AppendLine(", @cod_usuario");
                sql.AppendLine(", @accion");
                sql.AppendLine(", @cod_oficina_destino");
                sql.AppendLine(", @destino_vecino");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@fecha", obj.fecha);
                    cmd.Parameters.AddWithValue("@id_tramites", obj.id_tramites);
                    cmd.Parameters.AddWithValue("@id_oficina", obj.id_oficina);
                    cmd.Parameters.AddWithValue("@id_direccion", obj.id_direccion);
                    cmd.Parameters.AddWithValue("@id_secretaria", obj.id_secretaria);
                    cmd.Parameters.AddWithValue("@en_vecino", obj.en_vecino);
                    cmd.Parameters.AddWithValue("@cuit", obj.cuit);
                    cmd.Parameters.AddWithValue("@cod_usuario", obj.cod_usuario);
                    cmd.Parameters.AddWithValue("@accion", obj.accion);
                    cmd.Parameters.AddWithValue("@cod_oficina_destino", obj.cod_oficina_destino);
                    cmd.Parameters.AddWithValue("@destino_vecino", obj.destino_vecino);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Movimiento_tramites obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Movimiento_tramites SET");
                sql.AppendLine("fecha=@fecha");
                sql.AppendLine(", id_tramites=@id_tramites");
                sql.AppendLine(", id_oficina=@id_oficina");
                sql.AppendLine(", id_direccion=@id_direccion");
                sql.AppendLine(", id_secretaria=@id_secretaria");
                sql.AppendLine(", en_vecino=@en_vecino");
                sql.AppendLine(", cuit=@cuit");
                sql.AppendLine(", cod_usuario=@cod_usuario");
                sql.AppendLine(", accion=@accion");
                sql.AppendLine(", cod_oficina_destino=@cod_oficina_destino");
                sql.AppendLine(", destino_vecino=@destino_vecino");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@fecha", obj.fecha);
                    cmd.Parameters.AddWithValue("@id_tramites", obj.id_tramites);
                    cmd.Parameters.AddWithValue("@id_oficina", obj.id_oficina);
                    cmd.Parameters.AddWithValue("@id_direccion", obj.id_direccion);
                    cmd.Parameters.AddWithValue("@id_secretaria", obj.id_secretaria);
                    cmd.Parameters.AddWithValue("@en_vecino", obj.en_vecino);
                    cmd.Parameters.AddWithValue("@cuit", obj.cuit);
                    cmd.Parameters.AddWithValue("@cod_usuario", obj.cod_usuario);
                    cmd.Parameters.AddWithValue("@accion", obj.accion);
                    cmd.Parameters.AddWithValue("@cod_oficina_destino", obj.cod_oficina_destino);
                    cmd.Parameters.AddWithValue("@destino_vecino", obj.destino_vecino);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Movimiento_tramites obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Movimiento_tramites ");
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

