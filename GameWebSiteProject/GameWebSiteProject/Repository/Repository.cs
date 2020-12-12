using GameWebSiteProject.DBContext;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebSiteProject.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private IDataSourceProvider<T> DbContext { get; }
        public Repository(IConfiguration configuration)
        {
            DbContext = new DbProvider<T>(configuration);
        }
        public void Delete(params string[] conditon)
        {
            DbContext.DeleteWhere(new T().GetType(), conditon);
        }

        public IEnumerable<T> GetAll()
        {
            return DbContext.GetAll(new T().GetType());
        }

        public T GetBy(params string[] conditon)
        {
            return DbContext.GetBy(new T().GetType(), conditon);
        }

        public void Insert(T item)
        {
            DbContext.Add(item);
        }

        public void Update(T item)
        {
            DbContext.Update(item);
        }
    }
}
