using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Oficinas : DALBase
    {
        public int codigo_oficina { get; set; }
        public string nombre_oficina { get; set; }
        public bool secretaria { get; set; }
        public bool activo { get; set; }
        public string subsistema { get; set; }
        public Int16 vecino_digital { get; set; }
        public Int16 Genera_multas { get; set; }

        public Oficinas()
        {
            codigo_oficina = 0;
            nombre_oficina = string.Empty;
            secretaria = false;
            activo = false;
            subsistema = string.Empty;
            vecino_digital = 0;
            Genera_multas = 0;
        }

        private static List<Oficinas> mapeo(SqlDataReader dr)
        {
            List<Oficinas> lst = new List<Oficinas>();
            Oficinas obj;
            if (dr.HasRows)
            {
                int codigo_oficina = dr.GetOrdinal("codigo_oficina");
                int nombre_oficina = dr.GetOrdinal("nombre_oficina");
                int secretaria = dr.GetOrdinal("secretaria");
                int activo = dr.GetOrdinal("activo");
                int subsistema = dr.GetOrdinal("subsistema");
                int vecino_digital = dr.GetOrdinal("vecino_digital");
                int Genera_multas = dr.GetOrdinal("Genera_multas");
                while (dr.Read())
                {
                    obj = new Oficinas();
                    if (!dr.IsDBNull(codigo_oficina)) { obj.codigo_oficina = dr.GetInt32(codigo_oficina); }
                    if (!dr.IsDBNull(nombre_oficina)) { obj.nombre_oficina = dr.GetString(nombre_oficina); }
                    if (!dr.IsDBNull(secretaria)) { obj.secretaria = dr.GetBoolean(secretaria); }
                    if (!dr.IsDBNull(activo)) { obj.activo = dr.GetBoolean(activo); }
                    if (!dr.IsDBNull(subsistema)) { obj.subsistema = dr.GetString(subsistema); }
                    if (!dr.IsDBNull(vecino_digital)) { obj.vecino_digital = dr.GetInt16(vecino_digital); }
                    if (!dr.IsDBNull(Genera_multas)) { obj.Genera_multas = dr.GetInt16(Genera_multas); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Oficinas> read()
        {
            try
            {
                List<Oficinas> lst = new List<Oficinas>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Oficinas ORDER BY nombre_oficina";
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

        public static Oficinas getByPk(
        int codigo_oficina)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Oficinas WHERE");
                sql.AppendLine("codigo_oficina = @codigo_oficina");
                Oficinas obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@codigo_oficina", codigo_oficina);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Oficinas> lst = mapeo(dr);
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

        public static int insert(Oficinas obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Oficinas(");
                sql.AppendLine("codigo_oficina");
                sql.AppendLine(", nombre_oficina");
                sql.AppendLine(", secretaria");
                sql.AppendLine(", activo");
                sql.AppendLine(", subsistema");
                sql.AppendLine(", vecino_digital");
                sql.AppendLine(", Genera_multas");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@codigo_oficina");
                sql.AppendLine(", @nombre_oficina");
                sql.AppendLine(", @secretaria");
                sql.AppendLine(", @activo");
                sql.AppendLine(", @subsistema");
                sql.AppendLine(", @vecino_digital");
                sql.AppendLine(", @Genera_multas");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@codigo_oficina", obj.codigo_oficina);
                    cmd.Parameters.AddWithValue("@nombre_oficina", obj.nombre_oficina);
                    cmd.Parameters.AddWithValue("@secretaria", obj.secretaria);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@subsistema", obj.subsistema);
                    cmd.Parameters.AddWithValue("@vecino_digital", obj.vecino_digital);
                    cmd.Parameters.AddWithValue("@Genera_multas", obj.Genera_multas);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Oficinas obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Oficinas SET");
                sql.AppendLine("nombre_oficina=@nombre_oficina");
                sql.AppendLine(", secretaria=@secretaria");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine(", subsistema=@subsistema");
                sql.AppendLine(", vecino_digital=@vecino_digital");
                sql.AppendLine(", Genera_multas=@Genera_multas");
                sql.AppendLine("WHERE");
                sql.AppendLine("codigo_oficina=@codigo_oficina");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@codigo_oficina", obj.codigo_oficina);
                    cmd.Parameters.AddWithValue("@nombre_oficina", obj.nombre_oficina);
                    cmd.Parameters.AddWithValue("@secretaria", obj.secretaria);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@subsistema", obj.subsistema);
                    cmd.Parameters.AddWithValue("@vecino_digital", obj.vecino_digital);
                    cmd.Parameters.AddWithValue("@Genera_multas", obj.Genera_multas);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Oficinas obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Oficinas ");
                sql.AppendLine("WHERE");
                sql.AppendLine("codigo_oficina=@codigo_oficina");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@codigo_oficina", obj.codigo_oficina);
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

