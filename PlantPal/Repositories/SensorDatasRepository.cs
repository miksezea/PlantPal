using PlantPalLib.Models;

namespace PlantPal.Repositories
{
    public class SensorDatasRepository : ISensorDatasRepository
    {
        public int _nextId;
        public List<SensorData> _data;
        public SensorDatasRepository()
        {
            _nextId = 1;
            _data = new List<SensorData>()
            {
                new SensorData { Id = _nextId++, DateTime = "02/05/2023, 11:09:30", Conductivity = 50, Moisture = 4, Temperature = 50, Light = 2 },
                new SensorData { Id = _nextId++, DateTime = "02/05/2023, 11:09:30", Conductivity = 75, Moisture = 5, Temperature = 150, Light = 4 },
                new SensorData { Id = _nextId++, DateTime = "02/05/2023, 11:09:30", Conductivity = 25 , Moisture = 6, Temperature = 70, Light = 50 },
            };
        }

        public List<SensorData> GetAll()
        {
            return new List<SensorData>(_data);
        }

        public SensorData? GetById(int id)
        {
            return _data.Find(x => x.Id == id);
        }

        public SensorData Add(SensorData newSensorData)
        {
            if (newSensorData == null)
            {
                throw new ArgumentNullException(nameof(newSensorData), "SensorData cannot be null.");
            }
            newSensorData.Id = _nextId++;
            _data.Add(newSensorData);
            return newSensorData;
        }

        public SensorData? Delete(int id)
        {
            SensorData foundSensorData = GetById(id);
            if (foundSensorData != null)
            {
                _data.Remove(foundSensorData);
            }
            return foundSensorData;
        }                            
    }
}
