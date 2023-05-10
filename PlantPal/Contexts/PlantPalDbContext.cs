using Microsoft.EntityFrameworkCore;
using PlantPalLib.Models;

namespace PlantPal.Contexts

{
    public class SensorDataDbContext : DbContext
    {
        public SensorDataDbContext(DbContextOptions<SensorDataDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("PlantPalDbConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<SensorData> sensordata { get; set; }
        public DbSet<Plant> plants { get; set; }
    }
}

