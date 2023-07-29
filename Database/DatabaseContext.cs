using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebProject.Entities;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace WebProject.Database
{
    public class DatabaseContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Product> Products { get; set; } //database has 1 table named "Products", and all columns corresponding to Product
        public DbSet<User> Users {get;set;} // table Users
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Book> Books{ get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Address> Addresses { get; set; }


        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new NpgsqlDataSourceBuilder(_configuration.GetConnectionString("DefaultConnection"));
            optionsBuilder.UseNpgsql(builder.Build()).UseSnakeCaseNamingConvention();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) // fluent api methods
        {
            modelBuilder.Entity<User>()
            .HasOne(u => u.Address)
            .WithOne(a => a.User)
            .HasForeignKey<Address>(a => a.Id);

            /* modelBuilder.Entity<OrderProduct>()
            .HasOne(orderProduct => orderProduct.Order)
            .WithMany(order =>order.OrderProducts)
            .OnDelete(DeleteBehavior.SetNull); */

            modelBuilder.Entity<Address>()
            .ToTable(address => address.HasCheckConstraint("CK_PostCode_Length", "LENGTH(post_code) = 6"));
        }   
    }
}