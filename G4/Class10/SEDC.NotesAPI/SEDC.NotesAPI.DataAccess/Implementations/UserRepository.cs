using SEDC.NotesAPI.DataAccess.Interfaces;
using SEDC.NotesAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.NotesAPI.DataAccess.Implementations
{
    public class UserRepository : IUserRepository
    {
        private NotesAppDbContext _notesAppDbContext;
        public UserRepository(NotesAppDbContext notesAppDbContext)
        {
            _notesAppDbContext = notesAppDbContext;
        }

        public void Add(User entity)
        {
            _notesAppDbContext.Users.Add(entity);
            _notesAppDbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return _notesAppDbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _notesAppDbContext
                .Users
                .FirstOrDefault(x => x.Id == id);
            ;
        }

        public User GetUserByUsername(string username)
        {
            return _notesAppDbContext.Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
        }

        public User LoginUser(string username, string password)
        {
            return _notesAppDbContext.Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower()
            && x.Password == password);
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
