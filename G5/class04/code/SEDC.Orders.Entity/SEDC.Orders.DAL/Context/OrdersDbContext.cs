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


        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //modelBuilder.Entity<Order>().ToTable("Orders");
            // one to many relationship configuration
            modelBuilder.Entity<Order>(entity => 
            {
                entity.Property(p => p.Address).HasMaxLength(30);
                entity.Property(p => p.IsDelievered).IsRequired();
                entity.Property(p => p.OrderNumber).HasColumnName("order-number");

                entity.HasOne(x => x.User)
                      .WithMany(x => x.Orders)
                      .HasForeignKey(x => x.UserId)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("MyFKConstraint");
            });

        }
    }
}
