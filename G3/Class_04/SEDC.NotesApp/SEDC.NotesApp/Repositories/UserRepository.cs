using SEDC.NotesApp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.NotesApp.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public void Add(User entity)
        {
            entity.Id = StaticDb.Users.Count + 1;
            StaticDb.Users.Add(entity);
        }

        public List<User> GetAll()
        {
            return StaticDb.Users;
        }

        public User GetById(int id)
        {
            return StaticDb.Users.SingleOrDefault(user => user.Id == id);
        }

        public void Remove(int id)
        {
            User user = StaticDb.Users.SingleOrDefault(user => user.Id == id);
            if (user == null)
            {
                throw new Exception("No such user");
            }
            StaticDb.Users.Remove(user);
        }

        public void Update(User entity)
        {
            User user = StaticDb.Users.SingleOrDefault(user => user.Id == entity.Id);
            if (user == null)
            {
                throw new Exception("No such user");
            }
            int idxOfExistingUser = StaticDb.Users.IndexOf(user);
            StaticDb.Users[idxOfExistingUser] = entity;
        }
    }
}
