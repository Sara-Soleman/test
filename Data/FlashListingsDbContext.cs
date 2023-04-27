using Flash_listings.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace Flash_listings.Data
{
    public class FlashListingsDbContext : DbContext
    {
        public FlashListingsDbContext(DbContextOptions<FlashListingsDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Seed Category data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, NameEn = "Category 1", NameAr = "الفئة 1" },
                new Category { Id = 2, NameEn = "Category 2", NameAr = "الفئة 2" },
                new Category { Id = 3, NameEn = "Category 3", NameAr = "الفئة 3" }
            );
        }

        public DbSet<Flash_listings.Models.CustomFieldKeyValue> CustomFieldKeyValue { get; set; }

    }
}
