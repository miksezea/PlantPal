using PlantPalLib.Models;

namespace PlantPal.Repositories
{
        public interface ISensorDatasRepository
        {
            SensorData Add(SensorData newSensorData); // Tilføj sensordata
            SensorData Delete(int Id); // Slet sensordata
            List<SensorData> GetAll(); // Hent alle sensordata
            SensorData GetById(int Id); // Hent sensordata ud fra Id
        }
    }

