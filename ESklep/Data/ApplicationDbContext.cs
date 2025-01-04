using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ESklep.Models;

namespace ESklep.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ESklep.Models.Product> Product { get; set; } = default!;
        public DbSet<ESklep.Models.Author> Author { get; set; } = default!;
        public DbSet<ESklep.Models.Category> Category { get; set; } = default!;
        public DbSet<ESklep.Models.DeliveryHeader> DeliveryHeader { get; set; } = default!;
        public DbSet<ESklep.Models.DeliveryPostion> DeliveryPostion { get; set; } = default!;
        public DbSet<ESklep.Models.OrderHeader> OrderHeader { get; set; } = default!;
        public DbSet<ESklep.Models.OrderPosition> OrderPosition { get; set; } = default!;
        public DbSet<ESklep.Models.Storehouse> Storehouse { get; set; } = default!;
        public DbSet<ESklep.Models.StorehouseName> StorehouseName { get; set; } = default!;
        public DbSet<ESklep.Models.Tax> Tax { get; set; } = default!;
        public DbSet<ESklep.Models.User> User { get; set; } = default!;
        public DbSet<ESklep.Models.UserTypes> UserTypes { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("C:\\Users\\IWONA\\source\\repos\\ESklep\\ESklep\\dbsettings.json").Build();

            string? host = configuration.GetConnectionString("PostgreSQLHost");
            string? port = configuration.GetConnectionString("PostgreSQLPort");
            string? database = configuration.GetConnectionString("PostgreSQLDatabase");
            string? username = configuration.GetConnectionString("PostgreSQLUsername");
            string? password = configuration.GetConnectionString("PostgreSQLPassword");

            optionsBuilder.UseNpgsql($"Host={host};Port={port};Database={database};Username={username};Password={password}");
        }
    }
}
