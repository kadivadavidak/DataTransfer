using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataTransfer
{
    internal class DataHandler
    {
        internal static SqlConnection Connect()
        {
            return new SqlConnection(
                $"Data Source={(object) ConfigurationManager.AppSettings["FromServerName"]};Initial Catalog={(object) ConfigurationManager.AppSettings["FromDatabaseName"]};User ID={(object) ConfigurationManager.AppSettings["FromServerUserName"]};Password={(object) ConfigurationManager.AppSettings["FromServerPassword"]}");
        }

        internal static DataTable GetData(string tableName) //string storedProcName, string fileLocation)
        {
            var dataTable = new DataTable();

            var sql = $"SELECT * FROM {tableName} T";

            using (var connection = Connect())
            {
                using (var selectCommand = new SqlCommand(sql, connection))
                {
                    using (var sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    {
                        selectCommand.CommandTimeout = 900000;
                        sqlDataAdapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
    }
}
