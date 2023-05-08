using PlantPalLib.Models;

namespace PlantPal.Repositories
    
{
    public class SensorDatasRepository
    {
        private int _nextId;
        public List<SensorData> _data;
        public SensorDatasRepository()
        {
            _nextId = 1;
            _data = new List<SensorData>()
            {
                new SensorData { Id = _nextId++, Humidity = 50, PHValue = 4 },
                new SensorData { Id = _nextId++, Humidity = 75, PHValue = 5 },
                new SensorData { Id = _nextId++, Humidity = 25 , PHValue = 6 },
            };
        }


        public List<SensorData> GetAll()
        {
            return new List<SensorData>(_data);
        }

        public SensorData? GetById(int Id)
        {
            return _data.Find(x => x.Id == Id);
        }

        public SensorData Add(SensorData newSensorData)
        {
            newSensorData.Id = _nextId++;
            _data.Add(newSensorData);
            return newSensorData;
        }

        public SensorData? Delete(int Id)
        {
            SensorData foundSensorData = GetById(Id);
            if (foundSensorData != null)
            {
                _data.Remove(foundSensorData);
            }
            return foundSensorData;
        }                            
    }
}
