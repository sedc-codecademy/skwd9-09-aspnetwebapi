using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.MovieWorkshop.DataAccess;
using SEDC.MovieWorkshop.DataModels;

namespace SEDC.MovieWorkshop.Services.Helpers
{
    public class DIModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MovieDbContext>(x => x.UseSqlServer(connectionString));

            services.AddTransient<IRepository<Movie>, MovieRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();

            return services;
        }
    }
}
