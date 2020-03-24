using DotnetORMS.Infra.DI.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace DotnetORMS.Infra.Dapper.Context
{
    public class DapperContext
    {
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(Configuration["ConnectionStrings:SqlServer"]);
            }
        }

        private IConfiguration Configuration { get; set; }


        public DapperContext()
        {
            Configuration = Injection.Configuration;
        }
    }
}
