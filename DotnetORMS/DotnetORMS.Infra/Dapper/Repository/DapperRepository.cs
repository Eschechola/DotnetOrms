using Dapper;
using DotnetORMS.Infra.Dapper.Context;
using DotnetORMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DotnetORMS.Infra.Dapper.Repository
{
    public class DapperRepository : IDisposable
    {
        private readonly DapperContext Context;

        public DapperRepository(DapperContext _context)
        {
            Context = _context;
        }

        public void Insert(User user)
        {
            using (var conn = Context.Connection)
            {
                conn.Open();
                var query = $"INSERT INTO [dbo].[dotnet_users] VALUES (@Name, @Email, @Age)";
                conn.Execute(query, user);
            }
        }

        public void Update(User user)
        {
            using (var conn = Context.Connection)
            {
                conn.Open();
                var query = $"UPDATE [dbo].[dotnet_users] SET dotnet_name = @Name, email = @Email, age = @Age WHERE id = @Id";
                conn.Execute(query, user);
            }
        }

        public void Delete(int id)
        {
            using (var conn = Context.Connection)
            {
                conn.Open();
                var query = $"DELETE FROM [dbo].[dotnet_users] WHERE id = {id}";
                conn.Execute(query);
            }
        }

        public User Get(int id)
        {
            using (var conn = Context.Connection)
            {
                conn.Open();
                var query = $"SELECT * FROM [dbo].[dotnet_users] WHERE id = {id}";

                return conn.Query<User>(query).First();
            }
        }

        public IList<User> GetAll()
        {
            using (var conn = Context.Connection)
            {
                conn.Open();
                var query = $"SELECT * FROM [dbo].[dotnet_users]";

                return conn.Query<User>(query).ToList();
            }

        }

        public void Dispose()
        {
            if (Context.Connection.State == ConnectionState.Open)
                Context.Connection.Close();
        }
    }
}
