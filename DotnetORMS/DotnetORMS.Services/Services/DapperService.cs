using DotnetORMS.Infra.Dapper.Repository;
using DotnetORMS.Interfaces;
using DotnetORMS.Models;
using System.Collections.Generic;

namespace DotnetORMS.Services
{
    public class DapperService : IService
    {
        public void Insert(User obj)
        {
            new DapperRepository().Insert(obj);
        }

        public void Update(User obj)
        {
            new DapperRepository().Update(obj);
        }

        public void Delete(int id)
        {
            new DapperRepository().Delete(id);
        }

        public User Get(int id)
        {
            return new DapperRepository().Get(id);
        }

        public IList<User> GetAll()
        {
            return new DapperRepository().GetAll();
        }
    }
}
