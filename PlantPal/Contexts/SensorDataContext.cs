using Microsoft.EntityFrameworkCore;
using PlantPalLib.Models;
using PlantPal.Secrets;

namespace PlantPal.Contexts
    
{
    public class SensorDataContext : DbContext
    {
        public SensorDataContext(DbContextOptions<SensorDataContext> options) : base(options) { }

        public SensorDataContext() : base() { }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Secrets.Secrets.ConnectionString);
        }
        */

        public DbSet<SensorData> sensordata { get; set; }
    }
}

