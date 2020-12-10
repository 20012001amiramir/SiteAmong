using System;
using System.Collections.Generic;
using GameWebSiteProject.Models;
using Microsoft.Extensions.Configuration;
using GameWebSiteProject.DBContext;

namespace GameWebSiteProject.Repository
{
    public class UserRepository:IRepository<User> 
    {
        private IDataSourceProvider<User> DbContext { get; }
        public UserRepository(IConfiguration configuration)
        {
            DbContext = new DbProvider<User>(configuration);
        }

        public void Insert(User user)
        {
            user.Id = Guid.NewGuid();
            user.Sex = "not defined";
            user.About = "About Me";
            DbContext.Add(user);
        }
        public User GetBy(string column, string value)
        {
           return DbContext.GetBy(column, value, new User().GetType());
        }
        public void Update(User user)
        {
            DbContext.Update(user);
        }
        public void Delete(string column, string value)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<User> GetAll()
        {
            return DbContext.GetAll(new User().GetType());
        }
    }
}
