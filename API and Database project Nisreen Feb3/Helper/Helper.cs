using Microsoft.Data.SqlClient;
using System.Data;

namespace API_and_Database_project_Nisreen_Feb3.Helper
{
    public class Helper
    {
        public static string connectionStrting = (@"Server=DESKTOP-EB4QPRI\SQLEXPRESS;Database=Resturent_ADO_Nisreen;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=true");
        #region NonQueryCommand
        public static int ExecuteNonQueryCommandHelper(string query, Dictionary<string, object> parms)
        {
            SqlConnection connection = new SqlConnection(Helper.connectionStrting);
            //setup command
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            if (parms != null)
                foreach (KeyValuePair<string, object> kvp in parms)
                {
                    command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                }
            //open connection
            connection.Open();
            //execute query
            int rows = command.ExecuteNonQuery();
            //close connection
            connection.Close();
            return rows;
        }
        #endregion

        #region querycommand
        public static DataTable ExecutenQueryCommandHelper(string query, Dictionary<string, object> parms)
        {
            SqlConnection connection = new SqlConnection(Helper.connectionStrting);
            //setup command
            SqlCommand command = new SqlCommand(query, connection);


            if (parms != null)
                foreach (KeyValuePair<string, object> kvp in parms)
                {
                    command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            sqlDataAdapter.Fill(table);
            return table;
        }
        #endregion

        #region QueryCommandHandleTheStoredProcedure
        public static DataTable QuerycommandHanleproc(string query, Dictionary<string, object> parms)
        {
            {
                SqlConnection connection = new SqlConnection(Helper.connectionStrting);
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                if (parms != null)
                    foreach (KeyValuePair<string, object> kvp in parms)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                connection.Open();
                DataTable table = new DataTable();
                sqlDataAdapter.Fill(table);
                return table;
            }
            #endregion
        }
    }
}
