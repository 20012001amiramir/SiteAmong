﻿using System;
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
        //public void Delete(params string [] identfrs)
        //{
        //    using (var command = new SqlCommand("DELETE FROM \"User\" WHERE Username = @username"))
        //    {
        //        command.Parameters.Add(new SqlParameter("username", identfrs[0]));
        //        ExecuteNonQuery(command);
        //    }
        //}

        //public IEnumerable<User> GetAll()
        //{
        //    using (var command = new SqlCommand("SELECT * FROM \"User\""))
        //    {
        //        return GetRecords(command);
        //    }
        //}


        public void Delete(params string[] identfrs)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
