using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> Addresss { get; set; }

        public string DbPath { get; }

        public ApplicationDbContext()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DbPath = Path.Join(path, "customers.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}
