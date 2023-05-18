using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class Pasos : DALBase
    {
        public int id { get; set; }
        public int id_tramites { get; set; }
        public int id_paso { get; set; }
        public int orden_paso { get; set; }
        public int id_ingreso_paso { get; set; }
        public int orden_ingreso_paso { get; set; }
        public string nombre_ingreso_paso { get; set; }
        public int row { get; set; }
        public int col { get; set; }
        public int id_formulario { get; set; }
        public int id_adjunto { get; set; }
        public int id_ddjj { get; set; }
        public Formularios objFormulario { get; set; }  
        public Ddjjs objDDJJs { get; set; }
        public Adjuntos objAdjuntos { get; set; }

        public Pasos()
        {
            id = 0;
            id_tramites = 0;
            id_paso = 0;
            orden_paso = 0;
            id_ingreso_paso = 0;
            orden_ingreso_paso = 0;
            nombre_ingreso_paso = string.Empty;
            row = 0;
            col = 0;
            id_formulario = 0;
            id_adjunto = 0;
            id_ddjj = 0;
            objFormulario = new Formularios();
            objDDJJs = new Ddjjs();
            objAdjuntos = new Adjuntos();
        }

        private static List<Pasos> mapeo(SqlDataReader dr)
        {
            List<Pasos> lst = new List<Pasos>();
            Pasos obj;
            if (dr.HasRows)
            {
                int id = dr.GetOrdinal("id");
                int id_tramites = dr.GetOrdinal("id_tramites");
                int id_paso = dr.GetOrdinal("id_paso");
                int orden_paso = dr.GetOrdinal("orden_paso");
                int id_ingreso_paso = dr.GetOrdinal("id_ingreso_paso");
                int orden_ingreso_paso = dr.GetOrdinal("orden_ingreso_paso");
                int nombre_ingreso_paso = dr.GetOrdinal("nombre_ingreso_paso");
                int row = dr.GetOrdinal("row");
                int col = dr.GetOrdinal("col");
                int id_formulario = dr.GetOrdinal("id_formulario");
                int id_adjunto = dr.GetOrdinal("id_adjunto");
                int id_ddjj = dr.GetOrdinal("id_ddjj");

                while (dr.Read())
                {
                    obj = new Pasos();
                    if (!dr.IsDBNull(id)) { obj.id = dr.GetInt32(id); }
                    if (!dr.IsDBNull(id_tramites)) { obj.id_tramites = dr.GetInt32(id_tramites); }
                    if (!dr.IsDBNull(id_paso)) { obj.id_paso = dr.GetInt32(id_paso); }
                    if (!dr.IsDBNull(orden_paso)) { obj.orden_paso = dr.GetInt32(orden_paso); }
                    if (!dr.IsDBNull(id_ingreso_paso)) { obj.id_ingreso_paso = dr.GetInt32(id_ingreso_paso); }
                    if (!dr.IsDBNull(orden_ingreso_paso)) { obj.orden_ingreso_paso = dr.GetInt32(orden_ingreso_paso); }
                    if (!dr.IsDBNull(nombre_ingreso_paso)) { obj.nombre_ingreso_paso = dr.GetString(nombre_ingreso_paso); }
                    if (!dr.IsDBNull(row)) { obj.row = dr.GetInt32(row); }
                    if (!dr.IsDBNull(col)) { obj.col = dr.GetInt32(col); }
                    if (!dr.IsDBNull(id_formulario)) { obj.id_formulario = dr.GetInt32(id_formulario); }
                    if (!dr.IsDBNull(id_adjunto)) { obj.id_adjunto = dr.GetInt32(id_adjunto); }
                    if (!dr.IsDBNull(id_ddjj)) { obj.id_ddjj = dr.GetInt32(id_ddjj); }

                    if (obj.id_formulario != 0)
                        obj.objFormulario = Formularios.getByIdPasos(obj.id);
                    if (obj.id_adjunto != 0)
                        obj.objAdjuntos = Adjuntos.getByIdPasos(obj.id);
                    if (obj.id_ddjj != 0)
                        obj.objDDJJs = Ddjjs.getByIdPasos(obj.id);
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Pasos> read(int id_tramites)
        {
            try
            {
                List<Pasos> lst = new List<Pasos>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Pasos WHERE id_tramites=@id_tramites";
                    cmd.Parameters.AddWithValue("@id_tramites", id_tramites);
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

        public static Pasos getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                Pasos obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT *FROM PASOS WHERE ID=@ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Pasos> lst = mapeo(dr);
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

        public static int insert(Pasos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Pasos(");
                sql.AppendLine("id_tramites");
                sql.AppendLine(", id_paso");
                sql.AppendLine(", orden_paso");
                sql.AppendLine(", id_ingreso_paso");
                sql.AppendLine(", orden_ingreso_paso");
                sql.AppendLine(", nombre_ingreso_paso");
                sql.AppendLine(", row");
                sql.AppendLine(", col");
                sql.AppendLine(", id_formulario");
                sql.AppendLine(", id_adjunto");
                sql.AppendLine(", id_ddjj");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_tramites");
                sql.AppendLine(", @id_paso");
                sql.AppendLine(", @orden_paso");
                sql.AppendLine(", @id_ingreso_paso");
                sql.AppendLine(", @orden_ingreso_paso");
                sql.AppendLine(", @nombre_ingreso_paso");
                sql.AppendLine(", @row");
                sql.AppendLine(", @col");
                sql.AppendLine(", @id_formulario");
                sql.AppendLine(", @id_adjunto");
                sql.AppendLine(", @id_ddjj");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tramites", obj.id_tramites);
                    cmd.Parameters.AddWithValue("@id_paso", obj.id_paso);
                    cmd.Parameters.AddWithValue("@orden_paso", obj.orden_paso);
                    cmd.Parameters.AddWithValue("@id_ingreso_paso", obj.id_ingreso_paso);
                    cmd.Parameters.AddWithValue("@orden_ingreso_paso", obj.orden_ingreso_paso);
                    cmd.Parameters.AddWithValue("@nombre_ingreso_paso", obj.nombre_ingreso_paso);
                    cmd.Parameters.AddWithValue("@row", obj.row);
                    cmd.Parameters.AddWithValue("@col", obj.col);
                    cmd.Parameters.AddWithValue("@id_formulario", obj.id_formulario);
                    cmd.Parameters.AddWithValue("@id_adjunto", obj.id_adjunto);
                    cmd.Parameters.AddWithValue("@id_ddjj", obj.id_ddjj);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Pasos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Pasos SET");
                sql.AppendLine("id_tramites=@id_tramites");
                sql.AppendLine(", id_paso=@id_paso");
                sql.AppendLine(", orden_paso=@orden_paso");
                sql.AppendLine(", id_ingreso_paso=@id_ingreso_paso");
                sql.AppendLine(", orden_ingreso_paso=@orden_ingreso_paso");
                sql.AppendLine(", nombre_ingreso_paso=@nombre_ingreso_paso");
                sql.AppendLine(", row=@row");
                sql.AppendLine(", col=@col");
                sql.AppendLine(", id_formulario=@id_formulario");
                sql.AppendLine(", id_adjunto=@id_adjunto");
                sql.AppendLine(", id_ddjj=@id_ddjj");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_tramites", obj.id_tramites);
                    cmd.Parameters.AddWithValue("@id_paso", obj.id_paso);
                    cmd.Parameters.AddWithValue("@orden_paso", obj.orden_paso);
                    cmd.Parameters.AddWithValue("@id_ingreso_paso", obj.id_ingreso_paso);
                    cmd.Parameters.AddWithValue("@orden_ingreso_paso", obj.orden_ingreso_paso);
                    cmd.Parameters.AddWithValue("@nombre_ingreso_paso", obj.nombre_ingreso_paso);
                    cmd.Parameters.AddWithValue("@row", obj.row);
                    cmd.Parameters.AddWithValue("@col", obj.col);
                    cmd.Parameters.AddWithValue("@id_formulario", obj.id_formulario);
                    cmd.Parameters.AddWithValue("@id_adjunto", obj.id_adjunto);
                    cmd.Parameters.AddWithValue("@id_ddjj", obj.id_ddjj);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Pasos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Pasos ");
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

