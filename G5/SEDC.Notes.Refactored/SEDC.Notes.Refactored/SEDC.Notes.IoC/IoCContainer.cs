using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.Notes.DataAccess.Context;
using SEDC.Notes.DataAccess.Repositories.Classes;
using SEDC.Notes.DataAccess.Repositories.Interfaces;
using SEDC.Notes.DomainModels;
using SEDC.Notes.Services.Classes;
using SEDC.Notes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Notes.IoC
{
    //Microsoft.Extensions.DependencyInjection
    //Microsoft.EntityFrameworkCore.SqlServer
    public static class IoCContainer
    {
        public static IServiceCollection ConfigureIoCContainer(IServiceCollection services, 
                                                               string connectionString)
        {
            services.AddDbContext<NotesAppDbContext>(x =>
            {
                x.UseSqlServer(connectionString);
            });


            //register repositories
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Note>, NoteRepository>();

            //regioster services
            services.AddTransient<IUserService, UserService>();


            return services;
        }
    }
}
