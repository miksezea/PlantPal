using Microsoft.EntityFrameworkCore;
using PlantPalLib.Models;

namespace PlantPal.Contexts

{
    public class PlantPalDbContext : DbContext
    {
        public PlantPalDbContext(DbContextOptions<PlantPalDbContext> options) : base(options) { }

        // Metode til at forbinde til databasen
        // Kode lånt fra kommentar i: https://stackoverflow.com/questions/29110241/how-do-you-configure-the-dbcontext-when-creating-migrations-in-entity-framework
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

