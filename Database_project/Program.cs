namespace Database_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
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
