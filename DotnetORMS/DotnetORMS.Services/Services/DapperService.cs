using DotnetORMS.Infra.Dapper.Repository;
using DotnetORMS.Interfaces;
using DotnetORMS.Models;
using System.Collections.Generic;

namespace DotnetORMS.Services
{
    public class DapperService : IService
    {
        private readonly DapperRepository Repository;

        public DapperService(DapperRepository _repository)
        {
            Repository = _repository;
        }

        public void Insert(User obj)
        {
            Repository.Insert(obj);
        }

        public void Update(User obj)
        {
            Repository.Update(obj);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        }

        public User Get(int id)
        {
            return Repository.Get(id);
        }

        public IList<User> GetAll()
        {
            return Repository.GetAll();
        }
    }
}
