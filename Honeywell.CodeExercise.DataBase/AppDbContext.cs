using Honeywell.CodeExercise.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeywell.CodeExercise.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Category Table
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Cat1" });
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 2, Name = "Cat2" });
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 3, Name = "Cat3" });
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 4, Name = "Cat4" });


            // Seed SubCategory Table
            modelBuilder.Entity<SubCategory>().HasData(new SubCategory
            {
                Id = 1,
                CategoryId = 1,
                Name = "SubCat1"
            });

            modelBuilder.Entity<SubCategory>().HasData(new SubCategory
            {
                Id = 2,
                CategoryId = 2,
                Name = "SubCat2"
            });

            modelBuilder.Entity<SubCategory>().HasData(new SubCategory
            {
                Id = 3,
                CategoryId = 3,
                Name = "SubCat3"
            });

            modelBuilder.Entity<SubCategory>().HasData(new SubCategory
            {
                Id = 4,
                CategoryId = 4,
                Name = "SubCat4"
            });


            // Seed Item Table
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 1,
                SubCategoryId = 1,
                Name = "Item1",
                Description = "Desc1"
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 2,
                SubCategoryId = 2,
                Name = "Item2",
                Description = "Desc2"
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 3,
                SubCategoryId = 3,
                Name = "Item3",
                Description = "Desc3"
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 4,
                SubCategoryId = 4,
                Name = "Item4",
                Description = "Desc4"
            });

        }
    }
}
