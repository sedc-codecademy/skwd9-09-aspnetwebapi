using SEDC.MovieWorkshop.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.MovieWorkshop.DataAccess
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public void Add(Movie entity)
        {
            if (entity != null)
            {
                _context.Movies.Add(entity);
                _context.SaveChanges();
            }
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _context.Movies.SingleOrDefault(x => x.Id == id);
        }
    }
}
