using PlantPalLib.Models;

namespace PlantPal.Repositories
{
        public interface ISensorDatasRepository 
        {
            SensorData Add(SensorData newSensorData);
            SensorData Delete(int Id);
            List<SensorData> GetAll();
            SensorData GetById(int Id);
        }
    }

