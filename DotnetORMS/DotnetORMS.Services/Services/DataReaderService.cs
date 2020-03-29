using DotnetORMS.Infra.DataReader.Repository;
using DotnetORMS.Interfaces;
using DotnetORMS.Models;
using System;
using System.Collections.Generic;

namespace DotnetORMS.Services
{
    public class DataReaderService : IService
    {
        private readonly DataReaderRepository Repository;

        public DataReaderService(DataReaderRepository _repository)
        {
            Repository = _repository;
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

        public void Insert(User user)
        {
            Repository.Insert(user);
        }

        public void Update(User user)
        {
            Repository.Update(user);
        }
    }
}
