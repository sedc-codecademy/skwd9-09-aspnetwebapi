using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.NotesApp.DataAccess;
using SEDC.NotesApp.DataAccess.Implementations;
using SEDC.NotesApp.Domain.Models;
using SEDC.NotesApp.Services.Implementations;
using SEDC.NotesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Helpers
{
    public class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NotesAppDbContext>(x =>
                x.UseSqlServer(connectionString));
        }

        public static void InjectRepository(IServiceCollection services)
        {
            services.AddTransient<IRepository<Note>, NoteRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<INoteService, NoteService>();
        }
    }
}
