using System.Collections.Generic;

namespace GameWebSiteProject.Repository
{
    public interface IRepository<T> where T : class
    {
        void Insert(T item);
        void Update(T item);
        void Delete(string column, string value);
        IEnumerable<T> GetAll();
        T GetBy(string column, string value);
    }
}
