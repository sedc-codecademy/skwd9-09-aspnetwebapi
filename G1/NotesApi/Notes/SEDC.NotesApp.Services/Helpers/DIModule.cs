using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.NotesApp.DataAccess;
using SEDC.NotesApp.DataAccess.ADONET;
using SEDC.NotesApp.DataAccess.Dapper;
using SEDC.NotesApp.DataAccess.EntityFramework;
using SEDC.NotesApp.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Services.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NoteDbContext>(x => x.UseSqlServer(connectionString));

            //Registering repository - ADO.NET
            //services.AddTransient<IRepository<Note>>(x => new NoteRepositoryADO(connectionString));
            //services.AddTransient<IRepository<User>>(x => new UserRepositoryADO(connectionString));

            //Registering repository - Dapper
            //services.AddTransient<IRepository<Note>>(x => new NoteRepositoryDapper(connectionString));
            //services.AddTransient<IRepository<User>>(x => new UserRepositoryDapper(connectionString));

            //Registering repository  - EntityFramework
            services.AddTransient<IRepository<Note>, NoteRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();

            return services;
        }
    }
}
