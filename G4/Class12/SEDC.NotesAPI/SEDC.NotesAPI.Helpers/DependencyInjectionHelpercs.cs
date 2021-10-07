using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SEDC.NotesAPI.DataAccess;
using SEDC.NotesAPI.DataAccess.Implementations;
using SEDC.NotesAPI.DataAccess.Interfaces;
using SEDC.NotesAPI.Domain.Models;
using SEDC.NotesAPI.Services.Implementations;
using SEDC.NotesAPI.Services.Interfaces;
using SEDC.NotesAPI.Shared.CustomEntities;
using System;
using System.Collections.Generic;
using System.Text;
using static SEDC.NotesAPI.DataAccess.Interfaces.IRepository;

namespace SEDC.NotesAPI.Helpers
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
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
