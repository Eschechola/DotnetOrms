using DotnetORMS.Infra.Entity.Repository;
using DotnetORMS.Interfaces;
using DotnetORMS.Models;
using System.Collections.Generic;

namespace DotnetORMS.Services
{
    public class EntityService : IService
    {
        public void Insert(User obj)
        {
            new EntityRepository().Insert(obj);
        }

        public void Update(User obj)
        {
            new EntityRepository().Update(obj);
        }

        public void Delete(int id)
        {
            new EntityRepository().Delete(id);
        }

        public User Get(int id)
        {
            return new EntityRepository().Get(id);
        }

        public IList<User> GetAll()
        {
            return new EntityRepository().GetAll();
        }
    }
}
