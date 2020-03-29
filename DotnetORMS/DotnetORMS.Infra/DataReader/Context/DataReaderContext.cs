using Microsoft.Data.SqlClient;
using System.Data;

namespace DotnetORMS.Infra.DataReader.Context
{
    public class DataReaderContext
    {
        private string ConnectionString;
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }

        public DataReaderContext(string connectionString)
        {
            ConnectionString = connectionString;
        }


        public void ExecuteQuery(string strQuery)
        {
            var conn = Connection;
            conn.Open();

            var command = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conn
            };

            command.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader(string strQuery)
        {
            var conn = Connection;
            conn.Open();

            var command = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conn
            };

            return command.ExecuteReader();
        }
    }
}
