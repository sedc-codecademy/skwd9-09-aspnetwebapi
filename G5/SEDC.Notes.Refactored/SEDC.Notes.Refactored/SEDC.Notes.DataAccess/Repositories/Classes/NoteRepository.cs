using SEDC.Notes.DataAccess.Repositories.Interfaces;
using SEDC.Notes.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Notes.DataAccess.Repositories.Classes
{
    public class NoteRepository : IRepository<Note>
    {
        public void Add(Note entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Note entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Note> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Note entity)
        {
            throw new NotImplementedException();
        }
    }
}
