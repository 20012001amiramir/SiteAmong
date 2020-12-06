using System.Collections.Generic;

namespace GameWebSiteProject.Repository
{
    public interface IRepository<T> where T : class
    {
        void Insert(T item);
        void Update(T item);
        void Delete(params string[] identfrs);
        IEnumerable<T> GetAll();
        T GetByIdentfrs(params string[] identfrs);
    }
}
