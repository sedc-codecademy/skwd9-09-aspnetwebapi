using SEDC.NotesApp.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.NotesApp.DataAccess.EntityFramework
{
    public class UserRepository : IRepository<User>
    {
        private readonly NoteDbContext _db;

        public UserRepository(NoteDbContext db)
        {
            _db = db;
        }

        public void Add(User entity)
        {
            _db.Users.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(User entity)
        {
            User user = _db.Users.SingleOrDefault(x => x.Id == entity.Id);
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public void Update(User entity)
        {
            User user = _db.Users.SingleOrDefault(x => x.Id == entity.Id);
            if (user != null)
            {
                user.Firstname = entity.Firstname;
                user.LastName = entity.LastName;
                user.Username = entity.Username;
                user.Password = entity.Password;
            }
            //_db.Update(entity);
            _db.SaveChanges();
        }
    }
}
