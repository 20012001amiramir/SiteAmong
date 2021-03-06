﻿using System.Collections.Generic;

namespace GameWebSiteProject.Repository
{
    public interface IRepository<T> where T : class
    {
        void Insert(T item);
        void Update(T item);
        void Delete(params string[] conditon);
        IEnumerable<T> GetAll();
        T GetBy(params string[] condition);
        IEnumerable<T> GetAllBy(params string[] condition);
    }
}
