using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp
{
    public class DataAccess
    {
        public void DoCommand(string connectionString, SqlCommand command)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlCommand createTableStreet = new SqlCommand(queryStreetTable, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch
                {
                    return;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        
    }
}
