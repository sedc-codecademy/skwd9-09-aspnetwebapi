using SEDC.MovieWorkshop.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.MovieWorkshop.DataAccess
{
    public class UserRepository : IRepository<User>
    {
        private readonly MovieDbContext _context;

        public UserRepository(MovieDbContext context)
        {
            _context = context;
        }
        public void Add(User entity)
        {
            if (entity != null)
            {
                _context.Users.Add(entity);
                _context.SaveChanges();
            }
        }

        public List<User> GetAll() => _context.Users.ToList();

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
