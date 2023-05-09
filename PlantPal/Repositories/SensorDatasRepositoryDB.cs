using PlantPal.Contexts;
using PlantPalLib.Models;
namespace PlantPal.Repositories
{
    public class SensorDatasRepositoryDB : ISensorDatasRepository
    {
        private SensorDataContext _context;
        
        public SensorDatasRepositoryDB(SensorDataContext context)
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
