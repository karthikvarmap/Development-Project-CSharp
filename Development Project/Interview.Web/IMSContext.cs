
using Interview.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Interview.Web
{
    public class IMSContext:DbContext
    {
    
        public IMSContext(DbContextOptions options): base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<CategoryAttributes> CategoryAttributes { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<ProductAttributes> ProductAttributes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding the data 

            modelBuilder.Entity<Product>().HasData(
                new Product { InstanceId=1, Name="Car", Description="four wheel drive super car", ProductImageUris=null, ValidSkus=null, CreatedTimestamp=System.DateTime.Today},
                 new Product { InstanceId = 2, Name = "Scooter", Description = "two wheel drive vehicle", ProductImageUris = null, ValidSkus = null, CreatedTimestamp = System.DateTime.Today }
                );

            modelBuilder.Entity<Categories>().HasData(
                new Categories { InstanceId = 1, Name = "Sedan", Description = "This is sedan desription", CreatedTimestamp = System.DateTime.Now });


            modelBuilder.Entity<CategoryAttributes>(ca =>
            {
                ca.HasData(new CategoryAttributes { InstanceId = 1, Key = "Size", Value = "20" });
                ca.HasKey(table => new {table.InstanceId, table.Key});
            });

            modelBuilder.Entity<ProductCategories>(pa =>
            {
                pa.HasKey(table => new { table.InstanceId, table.CategoryInstanceId });
            });

            modelBuilder.Entity<ProductAttributes>(pa =>
            {
                pa.HasKey(table => new { table.InstanceId, table.Key });
            });
        }
    }
}
