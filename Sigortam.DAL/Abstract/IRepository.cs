using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.DAL.Abstract
{
    public interface IRepository<T>
    {
        T GetById(int id);
        List<T> GetByAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetLastRecord();
    }
}
