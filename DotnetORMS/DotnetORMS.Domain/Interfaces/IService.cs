using DotnetORMS.Models;
using System.Collections.Generic;

namespace DotnetORMS.Interfaces
{
    public interface IService
    {
        void Insert(User user);
        void Update(User user);
        void Delete(int id);
        User Get(int id);
        IList<User> GetAll();
    }
}
