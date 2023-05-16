using PlantPal.Contexts;
using PlantPalLib.Models;

namespace PlantPal.Repositories
{
    public class PlantsRepositoryDb : IPlantsRepository
    {
        private PlantPalDbContext _context;
        
        public PlantsRepositoryDb(PlantPalDbContext context)
        {
            _context = context;
        }

        public Plant Add(Plant newPlant) // Tilføj plante
        {
            newPlant.PlantId = null; // Sætter Id til null, så den automatisk bliver tildelt
            _context.plants.Add(newPlant); // Tilføjer plante til context
            _context.SaveChanges(); // Gemmer ændringer i context
            return newPlant; // Returnerer plante
        }

        public Plant? Delete(int Id) // Slet plante
        {
            Plant? plantBeDeleted = GetById(Id); // Henter plante ud fra Id
            if (plantBeDeleted != null) // Hvis plante ikke er null
            {
                _context.plants.Remove(plantBeDeleted); // Slet plante
                _context.SaveChanges(); // Gem ændringer i context
            }
            return plantBeDeleted; // Returner plante
        }

        public List<Plant> GetAll() // Hent alle planter
        {
            return _context.plants.ToList(); // Returner alle planter. ToList() konverterer til liste.
        }

        public Plant? GetById(int Id) // Hent plante ud fra Id
        {
            return _context.plants.Find(Id); // Returner plante ud fra Id
        }

        public Plant? Update(int Id, Plant updates) // Opdater plante
        {
            Plant? updatedPlant = _context.plants.Find(Id); // Henter plante ud fra Id
            if (updatedPlant != null) // Hvis plante ikke er null
            {
                // Opdater plante
                updatedPlant.Name = updates.Name;
                updatedPlant.Description = updates.Description;
                updatedPlant.Status = updates.Status;
                _context.SaveChanges(); // Gem ændringer i context
            }
            return updatedPlant; // Returner opdateret plante
        }
        public Plant? UpdateSelected(int Id) // Opdater plante
        {
            Plant? updatedPlant = _context.plants.Find(Id); // Henter plante ud fra Id
            if (updatedPlant != null) // Hvis plante ikke er null
            {
                // Opdater plante
                _context.SaveChanges(); // Gem ændringer i context
            }
            return updatedPlant; // Returner opdateret plante
        }
    }
}
