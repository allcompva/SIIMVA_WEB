using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOTOR_WORKFLOW.Entities
{
    public class contenido_ingreso_paso : DALBase
    {
        public int id { get; set; }
        public int id_ingreso_paso { get; set; }
        public int id_formulario { get; set; }
        public int id_adjunto { get; set; }
        public int id_ddjj { get; set; }
        public int orden { get; set; }
        public int row { get; set; }
        public int col { get; set; }
        public bool activo { get; set; }

        public Formulario objFormulario { get; set; }
        public Adjunto objAdjunto { get; set; }
        public ddjj objDDJJ { get; set; }

        public contenido_ingreso_paso()
        {
            id = 0;
            id_ingreso_paso = 0;
            id_formulario = 0;
            id_adjunto = 0;
            id_ddjj = 0;
            orden = 0;
            row = 0;
            col = 0;
            activo = false;
            objFormulario = new Formulario();
            objAdjunto = new Adjunto();
            objDDJJ = new ddjj();
        }

        private static List<contenido_ingreso_paso> mapeo(SqlDataReader dr)
        {
            List<contenido_ingreso_paso> lst = new List<contenido_ingreso_paso>();
            contenido_ingreso_paso obj;
            if (dr.HasRows)
            {
                int ID = dr.GetOrdinal("id");
                int ID_INGRESO_PASO = dr.GetOrdinal("id_ingreso_paso");
                int ID_FORMULARIO = dr.GetOrdinal("id_formulario");
                int ID_ADJUNTO = dr.GetOrdinal("id_adjunto");
                int ID_DDJJ = dr.GetOrdinal("id_ddjj");
                int ORDEN = dr.GetOrdinal("orden");
                int ROW = dr.GetOrdinal("row");
                int COL = dr.GetOrdinal("col");
                int ACTIVO = dr.GetOrdinal("activo");
                while (dr.Read())
                {
                    obj = new contenido_ingreso_paso();
                    if (!dr.IsDBNull(ID)) { obj.id = dr.GetInt32(ID); }
                    if (!dr.IsDBNull(ID_INGRESO_PASO)) { obj.id_ingreso_paso = dr.GetInt32(ID_INGRESO_PASO); }
                    if (!dr.IsDBNull(ID_FORMULARIO)) { obj.id_formulario = dr.GetInt32(ID_FORMULARIO); }
                    if (!dr.IsDBNull(ID_ADJUNTO)) { obj.id_adjunto = dr.GetInt32(ID_ADJUNTO); }
                    if (!dr.IsDBNull(ID_DDJJ)) { obj.id_ddjj = dr.GetInt32(ID_DDJJ); }
                    if (!dr.IsDBNull(ORDEN)) { obj.orden = dr.GetInt32(ORDEN); }
                    if (!dr.IsDBNull(ROW)) { obj.row = dr.GetInt32(ROW); }
                    if (!dr.IsDBNull(COL)) { obj.col = dr.GetInt32(COL); }
                    if (!dr.IsDBNull(ACTIVO)) { obj.activo = dr.GetBoolean(ACTIVO); }

                    if (obj.id_formulario != 0)
                        obj.objFormulario = Formulario.getByPk(obj.id_formulario);
                    if (obj.id_adjunto != 0)
                        obj.objAdjunto = Adjunto.getByPk(obj.id_adjunto);
                    if (obj.id_ddjj != 0)
                        obj.objDDJJ = ddjj.getByPk(obj.id_ddjj);

                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<contenido_ingreso_paso> read(int idIngresoPaso)
        {
            try
            {
                List<contenido_ingreso_paso> lst = new List<contenido_ingreso_paso>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        @"SELECT 
	                        A.*,
	                        B.id AS id_formulario,
	                        C.id AS id_adjunto,
	                        D.id AS id_ddjj
                        FROM contenido_ingreso_paso A
                        LEFT JOIN FORMULARIO B ON A.id=B.id_contenido_ingreso_paso
                        LEFT JOIN ADJUNTO C ON A.id=C.id_contenido_ingreso_paso
                        LEFT JOIN DDJJ D ON A.id=D.id_contenido_ingreso_paso
                        WHERE id_ingreso_paso=@id_ingreso_paso";
                    cmd.Parameters.AddWithValue("@id_ingreso_paso", idIngresoPaso);
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

        public static contenido_ingreso_paso getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM contenido_ingreso_paso WHERE");
                sql.AppendLine("id = @id");
                contenido_ingreso_paso obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = 
                        @"SELECT 
	                        A.*,
	                        B.id AS id_formulario,
	                        C.id AS id_adjunto,
	                        D.id AS id_ddjj
                        FROM contenido_ingreso_paso A
                        LEFT JOIN FORMULARIO B ON A.id=B.id_pasos
                        LEFT JOIN ADJUNTO C ON A.id=C.id_pasos
                        LEFT JOIN DDJJ D ON A.id=D.id_pasos
                        WHERE A.id=@id";
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<contenido_ingreso_paso> lst = mapeo(dr);
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

        public static int insert(contenido_ingreso_paso obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO contenido_ingreso_paso(");
                sql.AppendLine("id_ingreso_paso");
                sql.AppendLine(", id_formulario");
                sql.AppendLine(", id_adjunto");
                sql.AppendLine(", id_ddjj");
                sql.AppendLine(", orden");
                sql.AppendLine(", row");
                sql.AppendLine(", col");
                sql.AppendLine(", activo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id_ingreso_paso");
                sql.AppendLine(", @id_formulario");
                sql.AppendLine(", @id_adjunto");
                sql.AppendLine(", @id_ddjj");
                sql.AppendLine(", @orden");
                sql.AppendLine(", @row");
                sql.AppendLine(", @col");
                sql.AppendLine(", @activo");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_ingreso_paso", obj.id_ingreso_paso);
                    cmd.Parameters.AddWithValue("@id_formulario", obj.id_formulario);
                    cmd.Parameters.AddWithValue("@id_adjunto", obj.id_adjunto);
                    cmd.Parameters.AddWithValue("@id_ddjj", obj.id_ddjj);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@row", obj.row);
                    cmd.Parameters.AddWithValue("@col", obj.col);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(contenido_ingreso_paso obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  contenido_ingreso_paso SET");
                sql.AppendLine("id_ingreso_paso=@id_ingreso_paso");
                sql.AppendLine(", id_formulario=@id_formulario");
                sql.AppendLine(", id_adjunto=@id_adjunto");
                sql.AppendLine(", id_ddjj=@id_ddjj");
                sql.AppendLine(", orden=@orden");
                sql.AppendLine(", row=@row");
                sql.AppendLine(", col=@col");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_ingreso_paso", obj.id_ingreso_paso);
                    cmd.Parameters.AddWithValue("@id_formulario", obj.id_formulario);
                    cmd.Parameters.AddWithValue("@id_adjunto", obj.id_adjunto);
                    cmd.Parameters.AddWithValue("@id_ddjj", obj.id_ddjj);
                    cmd.Parameters.AddWithValue("@orden", obj.orden);
                    cmd.Parameters.AddWithValue("@row", obj.row);
                    cmd.Parameters.AddWithValue("@col", obj.col);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(contenido_ingreso_paso obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  contenido_ingreso_paso ");
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

