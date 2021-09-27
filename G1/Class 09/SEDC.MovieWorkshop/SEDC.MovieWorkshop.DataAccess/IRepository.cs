using System.Collections.Generic;

namespace SEDC.MovieWorkshop.DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
    }
}
