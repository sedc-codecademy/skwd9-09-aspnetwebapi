using NoteApp.Domain;
using NoteApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotesApp.DataAccess.Implementations
{
    public class UserRepository : IRepository<User>
    {
        private NotesAppDbContext _notesAppDbContext;
        public UserRepository(NotesAppDbContext notesAppDbContext)
        {
            _notesAppDbContext = notesAppDbContext;
        }
        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User delete)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            return _notesAppDbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(User update)
        {
            throw new NotImplementedException();
        }
    }
}
