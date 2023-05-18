using System.Data.SqlClient;

namespace MOTOR_WORKFLOW.Entities
{
    public class DALBase
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                return new SqlConnection("Data Source=10.0.0.8;Initial Catalog=MOTOR_WORKFLOW;User id=general");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SqlConnection GetConnectionSIIMVA()
        {
            try
            {
                return new SqlConnection("Data Source=10.0.0.8;Initial Catalog=SIIMVA;User id=general");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
