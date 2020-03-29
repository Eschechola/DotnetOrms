using DotnetORMS.Infra.DataReader.Context;
using DotnetORMS.Models;
using System.Collections.Generic;


namespace DotnetORMS.Infra.DataReader.Repository
{
    public class DataReaderRepository
    {
        private readonly DataReaderContext Context;

        public DataReaderRepository(DataReaderContext _context)
        {
            Context = _context;
        }

        public void Insert(User user)
        {

            var query = $"INSERT INTO [dbo].[dotnet_users] VALUES ('{user.Name}', '{user.Email}', '{user.Age}')";
            Context.ExecuteQuery(query);

        }

        public void Update(User user)
        {

            var query = $"UPDATE [dbo].[dotnet_users] SET dotnet_name = '{user.Name}', email = '{user.Email}', age = '{user.Age}' WHERE id = {user.Id}";
            Context.ExecuteQuery(query);

        }

        public void Delete(int id)
        {
            var query = $"DELETE FROM [dbo].[dotnet_users] WHERE id = {id}";
            Context.ExecuteQuery(query);

        }

        public User Get(int id)
        {

            var query = $"SELECT * FROM [dbo].[dotnet_users] WHERE id = {id}";

            var reader = Context.ExecuteReader(query);
            User user = null;


            while (reader.Read())
            {
                user = new User
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Name = reader["dotnet_name"].ToString(),
                    Email = reader["email"].ToString(),
                    Age = int.Parse(reader["age"].ToString()),

                };

                break;
            }


            return user;

        }

        public IList<User> GetAll()
        {

            var query = $"SELECT * FROM [dbo].[dotnet_users]";

            var reader = Context.ExecuteReader(query);
            List<User> Users = null;

            while (reader.Read())
            {
                Users.Add(new User
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Name = reader["dotnet_name"].ToString(),
                    Email = reader["email"].ToString(),
                    Age = int.Parse(reader["age"].ToString()),

                });
            }

            return Users;
        }
    }
}
