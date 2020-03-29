using Microsoft.Data.SqlClient;

namespace DotnetORMS.Infra.Dapper.Context
{
    public class DapperContext
    {
        private string ConnectionString;
        public SqlConnection Connection
        { 
            get 
            {
                return new SqlConnection(ConnectionString);
            }
        }

        public DapperContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
