using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<NotesAppDbContext>(x =>
                x.UseSqlServer("Server=DESKTOP-VSQ43CM\\SQLEXPRESS;Database=NotesAppDbFluent;Trusted_Connection=True"));
        }
    }
}
