using Microsoft.EntityFrameworkCore;
using PlantPalLib.Models;

namespace PlantPal.Contexts
    
{
    public class SensorDataContext : DbContext
    {
        public SensorDataContext(DbContextOptions<SensorDataContext> options) : base(options) { }

        public SensorDataContext() : base() { }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("connectionId=PlantPalConnection");
        }
        

        public DbSet<SensorData> sensordata { get; set; }
    }
}

