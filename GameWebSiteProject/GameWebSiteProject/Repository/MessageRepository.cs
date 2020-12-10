using GameWebSiteProject.DBContext;
using GameWebSiteProject.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace GameWebSiteProject.Repository
{
    public class MessageRepository : IRepository<Message>
    {
        private IDataSourceProvider<Message> DbContext { get; }
        public MessageRepository(IConfiguration configuration)
        {
            DbContext = new DbProvider<Message>(configuration);
        }
        public void Insert(Message item)
        {
            DbContext.Add(item);
        }
        public void Delete(string column, string value)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Message> GetAll()
        {
            return DbContext.GetAll(new Message().GetType());
        }

        public Message GetBy(string column, string value)
        {
            return DbContext.GetBy(column, value, new Message().GetType());
        }      
        public void Update(Message item)
        {
            DbContext.Update(item);
        }
    }
}
