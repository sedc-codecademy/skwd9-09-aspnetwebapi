using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.Notes.DataAccess.Context;
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




            return services;
        }
    }
}
