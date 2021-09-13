using System.Collections.Generic;

namespace Notes.Repository.IRepository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
