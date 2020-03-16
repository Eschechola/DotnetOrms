using DotnetORMS.Models;
using System.Collections.Generic;

namespace DotnetORMS.Interfaces
{
    public interface IBaseService
    {
        IList<User> GetAll();
    }
}
