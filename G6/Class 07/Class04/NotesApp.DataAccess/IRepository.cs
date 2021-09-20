using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.DataAccess
{
    public interface IRepository<T>
    {
        //CRUD Methods
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T delete);
        void Update(T update);
    }
}
