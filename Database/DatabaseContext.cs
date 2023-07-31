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

    static DatabaseContext()
    {
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }
        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
      /*   public override int SaveChanges()
        {
            var addedEntries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added);
            
            foreach (var entry in addedEntries)
            {
                if(entry.Entity is TimeStamp hasTimestamp)
                {
                    hasTimestamp.CreatedAt = new DateOnly();
                    hasTimestamp.UpdatedAt = new DateOnly();
                    Console.WriteLine($"created: {hasTimestamp.CreatedAt}");
                }
            }
            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified);

                foreach (var entry in modifiedEntries)
                {
                    if (entry.Entity is TimeStamp hasTimestamp)
                    {
                        hasTimestamp.UpdatedAt = new DateOnly();
                    }
                }
            Console.WriteLine("entry is modified");
            return base.SaveChanges();
        } */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new NpgsqlDataSourceBuilder(_configuration.GetConnectionString("DefaultConnection"));
            optionsBuilder.AddInterceptors(new TimeStampIntercepter());
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