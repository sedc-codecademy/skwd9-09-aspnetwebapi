﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.MovieWorkshop.DataModels;

namespace SEDC.MovieWorkshop.DataModels.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    [Migration("20210927182628_UsersTable")]
    partial class UsersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SEDC.MovieWorkshop.DataModels.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Test description",
                            Genre = 1,
                            Title = "Gone in 60 seconds",
                            UserId = 1,
                            Year = 2000
                        },
                        new
                        {
                            Id = 2,
                            Description = "Test description",
                            Genre = 1,
                            Title = "Rambo 1",
                            UserId = 1,
                            Year = 1982
                        },
                        new
                        {
                            Id = 3,
                            Description = "Test description",
                            Genre = 1,
                            Title = "Rambo 2",
                            UserId = 1,
                            Year = 1985
                        },
                        new
                        {
                            Id = 4,
                            Description = "Test description",
                            Genre = 1,
                            Title = "Rambo 3",
                            UserId = 1,
                            Year = 1988
                        },
                        new
                        {
                            Id = 5,
                            Description = "Test description",
                            Genre = 5,
                            Title = "Harry Potter and the Philosopher's Stone",
                            UserId = 1,
                            Year = 2001
                        },
                        new
                        {
                            Id = 6,
                            Description = "Test description",
                            Genre = 1,
                            Title = "Grown Ups",
                            UserId = 1,
                            Year = 2010
                        });
                });

            modelBuilder.Entity("SEDC.MovieWorkshop.DataModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Subscription")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "John Smith",
                            Password = "111222333",
                            Subscription = 1,
                            UserName = "JohnS"
                        });
                });

            modelBuilder.Entity("SEDC.MovieWorkshop.DataModels.Movie", b =>
                {
                    b.HasOne("SEDC.MovieWorkshop.DataModels.User", "User")
                        .WithMany("Movies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
