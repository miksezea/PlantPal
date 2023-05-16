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

        public SensorData Add(SensorData newSensorData) // Tilføj sensordata
        {
            newSensorData.Id = null; // Sætter Id til null, så den automatisk bliver tildelt

            var selectedPlant = _context.plants.FirstOrDefault(p => p.PlantSelected == true); // Søger efter plante, der bool-værdien 'true' i PlantSelected

			newSensorData.Plant = selectedPlant; // Tilknytter sensordata til planten med PlantSelected 'true'

			_context.sensordata.Add(newSensorData); // Tilføjer sensordata til context
            _context.SaveChanges(); // Gemmer ændringer i context
            return newSensorData; // Returnerer sensordata
        }

        public SensorData? Delete(int Id) // Slet sensordata
        {
            SensorData? sensorDataBeDeleted = GetById(Id); // Henter sensordata ud fra Id
            if (sensorDataBeDeleted != null) // Hvis sensordata ikke er null
            {
                _context.sensordata.Remove(sensorDataBeDeleted); // Slet sensordata
                _context.SaveChanges(); // Gem ændringer i context
            }
            return sensorDataBeDeleted; // Returner sensordata
        }
           
        public List<SensorData> GetAll() // Hent alle sensordata
        {
            return _context.sensordata.ToList(); // Returner alle sensordata. ToList() konverterer til liste. 
        }

        public SensorData? GetById(int Id) // Hent sensordata ud fra Id
        {
            return _context.sensordata.Find(Id); // Returner sensordata ud fra Id
        }
    }
}
