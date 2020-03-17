using System.Collections.Generic;
using System.Linq;
using DotnetORMS.Infra.Entity.Context;
using DotnetORMS.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetORMS.Infra.Entity.Repository
{
    public class EntityRepository
    {
        private readonly EntityContext Context;

        public EntityRepository()
        {
            Context = new EntityContext();
        }

        public void Insert(User user)
        {
            Context.Add(user);
            Context.SaveChanges();
        }

        public void Update(User user)
        {
            Context.Entry(user).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = Get(id);
            Context.User.Remove(user);
            Context.SaveChanges();
        }

        public User Get(int id)
        {
            return Context.User.Where(x => x.Id == id).First();
        }

        public IList<User> GetAll()
        {
            return Context.User.ToList();
        }
    }
}
