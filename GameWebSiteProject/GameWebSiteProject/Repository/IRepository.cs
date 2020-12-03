using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebSiteProject.Repository
{
    interface IRepository<T> where T : class
    {
        void Insert(T item);
        void Update(T item);
        void Delete(params string[] identfrs);
        IEnumerable<T> GetAll();
        T GetByIdentfrs(params string[] identfrs);
    }
}
