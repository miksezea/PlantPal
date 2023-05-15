using Microsoft.EntityFrameworkCore;
using PlantPalLib.Models;

namespace PlantPal.Contexts

{
    public class PlantPalDbContext : DbContext
    {
        public PlantPalDbContext(DbContextOptions<PlantPalDbContext> options) : base(options) { } // Konstruktør til at oprette en instans af PlantPalDbContext

        // Kode lånt fra kommentar i: https://stackoverflow.com/questions/29110241/how-do-you-configure-the-dbcontext-when-creating-migrations-in-entity-framework
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Metode til at forbinde til databasen
		{
			if (!optionsBuilder.IsConfigured) // Hvis optionsBuilder ikke er konfigureret
            {
                IConfigurationRoot configuration = new ConfigurationBuilder() // Konfigurerer optionsBuilder
                    .SetBasePath(Directory.GetCurrentDirectory()) // Sætter stien til den nuværende mappe
                    .AddJsonFile("appsettings.json") // Tilføjer appsettings.json
                    .Build(); // Bygger konfigurationen
                var connectionString = configuration.GetConnectionString("PlantPalDbConnection"); // Henter connection string fra appsettings.json
                optionsBuilder.UseSqlServer(connectionString); // Bruger connection string til at forbinde til databasen
            }
        }

        public DbSet<SensorData> sensordata { get; set; }
        public DbSet<Plant> plants { get; set; }
    }
}

