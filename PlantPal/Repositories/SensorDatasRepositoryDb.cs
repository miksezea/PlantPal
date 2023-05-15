using PlantPal.Contexts;
using PlantPalLib.Models;

namespace PlantPal.Repositories
{
    public class SensorDatasRepositoryDb : ISensorDatasRepository
    {
        /// <summary>
        /// Forbindelse til context
        /// </summary>
        private PlantPalDbContext _context;
        
        /// <summary>
        /// Constructor til SensorDatasRepositoryDb
        /// </summary>
        /// <param name="context"></param>
        public SensorDatasRepositoryDb(PlantPalDbContext context)
        {
            _context = context;
        }

        public SensorData Add(SensorData newSensorData)
        {
            newSensorData.Id = null;

            // Søger efter plante, der bool-værdien 'true' i PlantSelected
            var selectedPlant = _context.plants.FirstOrDefault(p => p.PlantSelected == true);
            // Tilknytter sensordata til planten med PlantSelected 'true'
            newSensorData.Plant = selectedPlant;

            _context.sensordata.Add(newSensorData);
            _context.SaveChanges();
            return newSensorData;
        }
        public SensorData? Delete(int Id)
        {
            SensorData? sensorDataBeDeleted = GetById(Id);
            if (sensorDataBeDeleted != null)
            {
                _context.sensordata.Remove(sensorDataBeDeleted);
                _context.SaveChanges();
            }
            return sensorDataBeDeleted;
        }
            
        public List<SensorData> GetAll()
        {
            return _context.sensordata.ToList();
        }

        public SensorData? GetById(int Id)
        {
            return _context.sensordata.Find(Id);
        }
         

    }
}
