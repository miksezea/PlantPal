using PlantPal.Contexts;
using PlantPalLib.Models;

namespace PlantPal.Repositories
{
    public class SensorDatasRepositoryDB : ISensorDatasRepository
    {
        private SensorDataDbContext _context;
        
        public SensorDatasRepositoryDB(SensorDataDbContext context)
        {
            _context = context;
        }

        public SensorData Add(SensorData newSensorData)
        {
            newSensorData.Id = null;
            _context.sensordata.Add(newSensorData);
            _context.SaveChanges();
            return newSensorData;
        }
        public SensorData? Delete(int id)
        {
            SensorData? sensorDataBeDeleted = GetById(id);
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
