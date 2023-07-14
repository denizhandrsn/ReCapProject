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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brands>().ToTable("Brands", "dbo");
            modelBuilder.Entity<Brands>().Property(p => p.Id).HasColumnName("Id");
            modelBuilder.Entity<Brands>().Property(p => p.BrandId).HasColumnName("BrandId");
            modelBuilder.Entity<Brands>().Property(p => p.BrandName).HasColumnName("BrandName");

            modelBuilder.Entity<Car>().ToTable("Cars", "dbo");
            modelBuilder.Entity<Car>().Property(p => p.CarId).HasColumnName("CarId");
            modelBuilder.Entity<Car>().Property(p => p.BrandId).HasColumnName("BrandId");
            modelBuilder.Entity<Car>().Property(p => p.ColorId).HasColumnName("ColorId");
            modelBuilder.Entity<Car>().Property(p => p.ModelYear).HasColumnName("ModelYear");
            modelBuilder.Entity<Car>().Property(p => p.DailyPrice).HasColumnName("DailyPrice");
            modelBuilder.Entity<Car>().Property(p => p.Description).HasColumnName("Description");

            modelBuilder.Entity<Colors>().ToTable("Colors", "dbo");
            modelBuilder.Entity<Colors>().Property(p => p.Id).HasColumnName("Id");
            modelBuilder.Entity<Colors>().Property(p => p.ColorId).HasColumnName("ColorId");
            modelBuilder.Entity<Colors>().Property(p => p.ColorName).HasColumnName("ColorName");


        }

    }
}
