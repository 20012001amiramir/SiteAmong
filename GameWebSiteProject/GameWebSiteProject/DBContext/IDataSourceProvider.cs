using System;
using System.Collections.Generic;

namespace GameWebSiteProject.DBContext
{
    internal interface IDataSourceProvider<T> where T : class
    {
        void Add(T obj);
        void DeleteWhere(string column, string value, Type type);
        T GetBy(string column, string value, Type type);
        IEnumerable<T> GetAll(Type type);
        void Update(T obj);
    }
}
