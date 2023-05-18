using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Respuesta_formulario : DALBase
    {
        public int id { get; set; }
        public int id_formularios { get; set; }
        public string nombre_campo { get; set; }
        public string respuesta_usuario { get; set; }
        public int id_tipo_campo { get; set; }
        public int orden { get; set; }
        public string etiqueta_campo { get; set; }
        public Respuesta_formulario()
        {
            id = 0;
            id_formularios = 0;
            nombre_campo = string.Empty;
            respuesta_usuario = string.Empty;
            id_tipo_campo = 0;
            orden = 0;
            etiqueta_campo = string.Empty;
        }

        private static List<Respuesta_formulario> mapeo(SqlDataReader dr)
        {
            List<Respuesta_formulario> lst = new List<Respuesta_formulario>();
            Respuesta_formulario obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int id_formularios = dr.GetOrdinal("id_formularios");
                int nombre_campo = dr.GetOrdinal("nombre_campo");
                int respuesta_usuario = dr.GetOrdinal("respuesta_usuario");
                int id_tipo_campo = dr.GetOrdinal("id_tipo_campo");
                int orden = dr.GetOrdinal("orden");
                int etiqueta_campo = dr.GetOrdinal("etiqueta_campo");
                while (dr.Read())
                {
                    obj = new Respuesta_formulario();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(id_formularios)) { obj.id_formularios = dr.GetInt32(id_formularios); }
                    if (!dr.IsDBNull(nombre_campo)) { obj.nombre_campo = dr.GetString(nombre_campo); }
                    if (!dr.IsDBNull(respuesta_usuario)) { obj.respuesta_usuario = dr.GetString(respuesta_usuario); }
                    if (!dr.IsDBNull(id_tipo_campo)) { obj.id_tipo_campo = dr.GetInt32(id_tipo_campo); }
                    if (!dr.IsDBNull(orden)) { obj.orden = dr.GetInt32(orden); }
                    if (!dr.IsDBNull(etiqueta_campo)) { obj.etiqueta_campo = dr.GetString(etiqueta_campo); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Respuesta_formulario> read(int id_formularios)
        {
            try
            {
                List<Respuesta_formulario> lst = new List<Respuesta_formulario>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Respuesta_formulario WHERE id_formularios=@id_formularios";
                    cmd.Parameters.AddWithValue("@id_formularios", id_formularios);
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

        public static Respuesta_formulario getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Respuesta_formulario WHERE");
                Respuesta_formulario obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Respuesta_formulario> lst = mapeo(dr);
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

        public static int insert(Respuesta_formulario obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Respuesta_formulario(");
                sql.AppendLine("id_formularios");
                sql.AppendLine(", nombre_campo");
                sql.AppendLine(", respuesta_usuario");
                sql.AppendLine(", id_tipo_campo");
                sql.AppendLine(", orden");
                sql.AppendLine(", etiqueta_campo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");

                sql.AppendLine("@id_formularios");
                sql.AppendLine(", @nombre_campo");
                sql.AppendLine(", @respuesta_usuario");
                sql.AppendLine(", @id_tipo_campo");
                sql.AppendLine(", @orden");
                sql.AppendLine(", @etiqueta_campo");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_formularios", obj.id_formularios);
                    cmd.Parameters.AddWithValue("@nombre_campo", obj.nombre_campo);
                    cmd.Parameters.AddWithValue("@respuesta_usuario", obj.respuesta_usuario);
                    cmd.Parameters.AddWithValue("@id_tipo_campo", obj.id_tipo_campo);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@etiqueta_campo", obj.etiqueta_campo);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Respuesta_formulario obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Respuesta_formulario SET");
                sql.AppendLine("id_formularios=@id_formularios");
                sql.AppendLine(", nombre_campo=@nombre_campo");
                sql.AppendLine(", respuesta_usuario=@respuesta_usuario");
                sql.AppendLine(", id_tipo_campo=@id_tipo_campo");
                sql.AppendLine(", orden=@orden");
                sql.AppendLine(", etiqueta_campo=@etiqueta_campo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@id_formularios", obj.id_formularios);
                    cmd.Parameters.AddWithValue("@nombre_campo", obj.nombre_campo);
                    cmd.Parameters.AddWithValue("@respuesta_usuario", obj.respuesta_usuario);
                    cmd.Parameters.AddWithValue("@id_tipo_campo", obj.id_tipo_campo);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@etiqueta_campo", obj.etiqueta_campo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Respuesta_formulario obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Respuesta_formulario ");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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

