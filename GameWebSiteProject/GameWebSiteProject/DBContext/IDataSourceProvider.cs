using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebSiteProject.DBContext
{
    internal interface IDataSourceProvider<T> where T : class
    {
        void Add(T obj);
        void DeleteWhere(params string[] identfrs);
        T GetBy(string column, string value, Type type);
        ICollection<T> GetAll();
        void Update(T obj);
    }
}
