using Microsoft.EntityFrameworkCore;
using SEDC.Orders.DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Orders.DAL.Context
{
    //Entity Framework packages

    //Microsoft.EntityFrameworkCore.SqlServer
    //Microsoft.EntityFrameworkCore.SqlServer.Design
    //Microsoft.EntityFrameworkCore.Tools
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) {}

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
