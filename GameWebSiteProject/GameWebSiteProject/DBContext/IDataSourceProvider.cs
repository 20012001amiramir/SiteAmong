using System;
using System.Collections.Generic;

namespace GameWebSiteProject.DBContext
{
    internal interface IDataSourceProvider<T> where T : class
    {
        void Add(T obj);
        void DeleteWhere(Type type, params string[] conditon);
        T GetBy(Type type, params string[] condition);
        IEnumerable<T> GetAll(Type type);
        void Update(T obj);
        IEnumerable<T> GetAllBy(Type type, params string[] condition);

    }
}
