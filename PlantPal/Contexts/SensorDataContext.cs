using Microsoft.EntityFrameworkCore;
using PlantPalLib.Models;
namespace PlantPal.Contexts
    
{
    public class SensorDataContext : DbContext
    {
        public SensorDataContext(DbContextOptions<SensorDataContext> options) : base(options) { }

        public DbSet<SensorData> sensordata { get; set; }
    }
}
}
