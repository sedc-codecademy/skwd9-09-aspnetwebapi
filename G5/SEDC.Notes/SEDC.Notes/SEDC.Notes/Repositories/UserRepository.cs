using SEDC.Notes.Models.Data;
using SEDC.Notes.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Notes.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public void Add(User entity)
        {
            CacheDb.UserIdCounter++;
            entity.Id = CacheDb.UserIdCounter;
            CacheDb.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            var user = CacheDb.Users.FirstOrDefault(u => u.Id == entity.Id);

            if (user != null) 
            {
                CacheDb.Users.Remove(user);
            }
        }

        public List<User> GetAll()
        {
            return CacheDb.Users;
        }

        public void Update(User entity)
        {
            var user = CacheDb.Users.FirstOrDefault(u => u.Id == entity.Id);

            if (user != null) 
            {
                var indexOfUser = CacheDb.Users.IndexOf(user);
                CacheDb.Users[indexOfUser] = entity;

                //user.FirstName = entity.FirstName;
                //user.LastName = entity.LastName;
                //user.Username = entity.Username;
                //user.Password = entity.Password;
            }
        }
    }
}
