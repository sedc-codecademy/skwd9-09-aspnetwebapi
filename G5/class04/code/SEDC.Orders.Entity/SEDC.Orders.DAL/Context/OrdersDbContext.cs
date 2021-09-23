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
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            // one to many relationship configuration
            //modelBuilder.Entity<Order>().ToTable("Orders");
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


            //one to one relationship configuration
            modelBuilder.Entity<User>()
                        .HasOne(x => x.UserInfo)
                        .WithOne(x => x.User)
                        .HasForeignKey<UserInfo>(x => x.UserId);



            //many to many relationship configuration
            modelBuilder.Entity<OrderProduct>()
                        .HasKey(x => new { x.OrderId, x.ProductId });

            modelBuilder.Entity<OrderProduct>()
                        .HasOne(x => x.Order)
                        .WithMany(x => x.OrderProducts)
                        .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<OrderProduct>()
                        .HasOne(x => x.Product)
                        .WithMany(x => x.OrderProducts)
                        .HasForeignKey(x => x.OrderId);


            //seeding the database with data
            modelBuilder.Entity<User>().HasData(
                new User() 
                {
                    Id = 1,
                    FullName = "Viktor Jakovlev",
                    Username = "vjakovlev",
                    Password = "P@ssw0rd"
                }    
            );


            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    UserId = 1,
                    Address = "random address 1",
                    IsDelievered = false,
                    OrderCreationDate = DateTime.Now,
                    OrderNumber = 1111
                },
                new Order
                {
                    Id = 2,
                    UserId = 1,
                    Address = "random address 2",
                    IsDelievered = true,
                    OrderCreationDate = DateTime.Now,
                    OrderNumber = 2222
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product() 
                {
                    ProductId = 1,
                    ProductName = "Pizza"
                },
                new Product()
                {
                    ProductId = 2,
                    ProductName = "Burger"
                }
            );

            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct()
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1
                },
                new OrderProduct()
                {
                    Id = 2,
                    OrderId = 1,
                    ProductId = 2
                },
                new OrderProduct()
                {
                    Id = 3,
                    OrderId = 2,
                    ProductId = 1
                },
                new OrderProduct()
                {
                    Id = 4,
                    OrderId = 2,
                    ProductId = 2
                }
            );

        }
    }
}
