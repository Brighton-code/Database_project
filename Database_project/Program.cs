using Microsoft.EntityFrameworkCore;
using Database_project.Models;

namespace Database_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            using (UserContext context = new UserContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }

    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            optionsBuilder.UseSqlite(@$"Data Source={documentsPath}\Testing.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "John", Password = "12345678" },
                new User { Id = 2, Name = "Jane", Password = "password" },
                new User { Id = 3, Name = "Amber", Password = "12345678" }
            );
        }
    }

    public class Database
    {
        public void ConfigureServices(IServiceProvider services)
        {
            string connectionString = "server=localhost;user=root;password=password;database=test;";

            var serviceVersion = new MySqlServerVersion();
        }
    }
}
