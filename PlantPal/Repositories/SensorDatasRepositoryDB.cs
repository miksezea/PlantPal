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
           
            _context.sensordata.Add(newSensorData);
            _context.SaveChanges();
            return newSensorData;
        }
        public SensorData? Delete(int Id)
        {
            throw new NotImplementedException();
        }
            
        public List<SensorData> GetAll()
        {
            return _context.sensordata.ToList();

        }

        public SensorData? GetById(int Id)
        {
            throw new NotImplementedException();
        }
            






    }
}
