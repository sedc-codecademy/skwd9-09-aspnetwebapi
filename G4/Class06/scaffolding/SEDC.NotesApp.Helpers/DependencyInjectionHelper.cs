using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.NotesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services )
        {
            services.AddDbContext<NotesScaffoldedDbContext>(x =>
                x.UseSqlServer("Server=DESKTOP-VSQ43CM\\SQLExpress;Database=NotesScaffoldedDb;Trusted_Connection=True;"));
        }
    }
}
