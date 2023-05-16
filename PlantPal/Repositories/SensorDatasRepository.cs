using PlantPalLib.Models;

namespace PlantPal.Repositories
{
    public class SensorDatasRepository : ISensorDatasRepository // Implement ISensorDatasRepository. This is a repository for sensor data. It is used to store and retrieve sensor data. 
    {
        public int _nextId; 
        public List<SensorData> _data;

        public SensorDatasRepository() // Constructor
		{
            _nextId = 1; // Set next id to 1
            _data = new List<SensorData>() // Create a list of sensor data
            {
                new SensorData { Id = _nextId++, DateTime = "02/05/2023, 11:09:30", Conductivity = 50, Moisture = 4, Temperature = 50, Light = 2 },
                new SensorData { Id = _nextId++, DateTime = "02/05/2023, 11:09:30", Conductivity = 75, Moisture = 5, Temperature = 150, Light = 4 },
                new SensorData { Id = _nextId++, DateTime = "02/05/2023, 11:09:30", Conductivity = 25 , Moisture = 6, Temperature = 70, Light = 50 },
            };
        }

        public List<SensorData> GetAll() // Get all sensor data
		{
            return new List<SensorData>(_data); // Return a copy of the list rather than the list itself

		}


		public SensorData? GetById(int id) // Get sensor data by id
		{
            return _data.Find(x => x.Id == id); // Find and return the sensor data with the given id
		}

		public SensorData Add(SensorData newSensorData) // Add sensor data
        {
            if (newSensorData == null) // If input is null
            {
                throw new ArgumentNullException(nameof(newSensorData), "SensorData cannot be null."); // Return null

			}
			newSensorData.Id = _nextId++; // Set id
            _data.Add(newSensorData); // Add sensor data to list
            return newSensorData; // Return sensor data
        }

        public SensorData? Delete(int id) // Delete sensor data
        {
            SensorData foundSensorData = GetById(id); // Find sensor data with given id
            if (foundSensorData != null) // If sensor data is not null
            {
                _data.Remove(foundSensorData); // Remove sensor data from list
            }
            return foundSensorData; // Return sensor data
        }                            
    }
}
