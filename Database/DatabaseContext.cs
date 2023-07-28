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

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new NpgsqlDataSourceBuilder(_configuration.GetConnectionString("DefaultConnection"));
            optionsBuilder.UseNpgsql(builder.Build());
        }
    }
}