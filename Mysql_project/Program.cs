using Microsoft.EntityFrameworkCore;

namespace Mysql_project
{
    internal class Program
    {
        /**
         * dotnet add package Microsoft.EntityFrameworkCore --version 8.0.5
         * dotnet add package MySql.EntityFrameworkCore --version 8.0.5
         */
        static void Main(string[] args)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Database.EnsureCreated();
            }

            string userName = null;
            while (userName == null)
            {
                Console.WriteLine("Please enter a username");
                userName = Console.ReadLine();
            }

            string password = null;
            while (password == null)
            {
                Console.WriteLine("Please enter a password");
                password = Console.ReadLine();
            }

            User newUser = new User { Name = userName, Password = password };

            using (AppDbContext context = new AppDbContext())
            {
                context.Users.Add(newUser);
                context.SaveChanges();


                Console.WriteLine("Current users in Database:");
                context.Users.ToList().ForEach(s =>  Console.WriteLine($" -{s.Name}"));
            }
        }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySQL("server=localhost;database=test_database;user=root;password=password;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin", Password = "12345678" }
            );
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
