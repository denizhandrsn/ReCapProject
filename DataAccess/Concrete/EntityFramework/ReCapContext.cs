using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ReCapDatabase;Trusted_Connection=true");
        }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<CarImages> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Brands>().ToTable("Brands", "dbo");
        //    modelBuilder.Entity<Brands>().Property(p => p.Id).HasColumnName("Id");
        //    modelBuilder.Entity<Brands>().Property(p => p.BrandName).HasColumnName("BrandName");

        //    modelBuilder.Entity<Car>().ToTable("Cars", "dbo");
        //    modelBuilder.Entity<Car>().Property(p => p.Id).HasColumnName("Id");
        //    modelBuilder.Entity<Car>().Property(p => p.BrandId).HasColumnName("BrandId");
        //    modelBuilder.Entity<Car>().Property(p => p.ColorId).HasColumnName("ColorId");
        //    modelBuilder.Entity<Car>().Property(p => p.ModelYear).HasColumnName("ModelYear");
        //    modelBuilder.Entity<Car>().Property(p => p.DailyPrice).HasColumnName("DailyPrice");
        //    modelBuilder.Entity<Car>().Property(p => p.Description).HasColumnName("Description");

        //    modelBuilder.Entity<Colors>().ToTable("Colors", "dbo");
        //    modelBuilder.Entity<Colors>().Property(p => p.Id).HasColumnName("Id");
        //    modelBuilder.Entity<Colors>().Property(p => p.ColorName).HasColumnName("ColorName");

        //    modelBuilder.Entity<Users>().ToTable("Users", "dbo");
        //    modelBuilder.Entity<Users>().Property(p => p.Id).HasColumnName("Id");
        //    modelBuilder.Entity<Users>().Property(p => p.CustomerId).HasColumnName("CustomerId");
        //    modelBuilder.Entity<Users>().Property(p => p.FirstName).HasColumnName("FirstName");
        //    modelBuilder.Entity<Users>().Property(p => p.LastName).HasColumnName("LastName");
        //    modelBuilder.Entity<Users>().Property(p => p.Email).HasColumnName("Email");
        //    modelBuilder.Entity<Users>().Property(p => p.Password).HasColumnName("Password");

        //    modelBuilder.Entity<Rentals>().ToTable("Rentals", "dbo");
        //    modelBuilder.Entity<Rentals>().Property(p => p.Id).HasColumnName("Id");
        //    modelBuilder.Entity<Rentals>().Property(p => p.CarId).HasColumnName("CarId");
        //    modelBuilder.Entity<Rentals>().Property(p => p.UserId).HasColumnName("UserId");
        //    modelBuilder.Entity<Rentals>().Property(p => p.RentDate).HasColumnName("RentDate");
        //    modelBuilder.Entity<Rentals>().Property(p => p.ReturnDate).HasColumnName("ReturnDate");

        //    modelBuilder.Entity<Customers>().ToTable("Customers", "dbo");
        //    modelBuilder.Entity<Customers>().Property(p => p.Id).HasColumnName("Id");
        //    modelBuilder.Entity<Customers>().Property(p => p.CompanyName).HasColumnName("CompanyName");


        //    modelBuilder.Entity<CarImages>().ToTable("CarImages", "dbo");
        //    modelBuilder.Entity<CarImages>().Property(p => p.Id).HasColumnName("Id");
        //    modelBuilder.Entity<CarImages>().Property(p => p.CarId).HasColumnName("CarId");
        //    modelBuilder.Entity<CarImages>().Property(p => p.Date).HasColumnName("Date");
        //    modelBuilder.Entity<CarImages>().Property(p => p.ImagePath).HasColumnName("ImagePath");
        //}

    }
}
