using System.Collections.Generic;
using System.Data.SqlClient;
using GameWebSiteProject.DBContext;

namespace GameWebSiteProject.Repository
{
    public interface IRepository<T> where T : class
    {
        void Insert(T item);
        void Update(T item);
        void Delete(params string[] identfrs);
        IEnumerable<T> GetAll();
        T GetBy(string column, string value);
    }
}
