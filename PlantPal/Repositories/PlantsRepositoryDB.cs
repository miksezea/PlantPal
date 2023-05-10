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

        public Plant Add(Plant newPlant)
        {
            newPlant.PlantId = null;
            _context.plants.Add(newPlant);
            _context.SaveChanges();
            return newPlant;
        }

        public Plant? Delete(int Id)
        {
            Plant? plantBeDeleted = GetById(Id);
            if (plantBeDeleted != null)
            {
                _context.plants.Remove(plantBeDeleted);
                _context.SaveChanges();
            }
            return plantBeDeleted;
        }

        public List<Plant> GetAll()
        {
            return _context.plants.ToList();
        }

        public Plant? GetById(int Id)
        {
            return _context.plants.Find(Id);
        }
    }
}
