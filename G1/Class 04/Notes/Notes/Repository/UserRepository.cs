using Notes.Models.Data;
using Notes.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Notes.Repository
{
    public class UserRepository : IRepository<User>
    {
        public void Add(User entity)
        {
            CacheDb.UserId++;
            entity.Id = CacheDb.UserId;
            CacheDb.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            User user = CacheDb.Users.FirstOrDefault(x => x.Id == entity.Id);
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
            User user = CacheDb.Users.FirstOrDefault(x => x.Id == entity.Id);
            if (user != null)
            {
                user.Firstname = entity.Firstname;
                user.LastName = entity.LastName;
                user.Username = entity.Username;
                user.Password = entity.Password;
            }

        }
    }
}
