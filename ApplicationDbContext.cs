using DemoApplication.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DemoApplication
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TimeTable> time_table { get; set; }
        public DbSet<HallCapacity> hall_capacities { get; set; }
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("The connection string was not found.");
            }

            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
