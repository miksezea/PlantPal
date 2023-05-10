using PlantPal.Contexts;
using PlantPalLib.Models;

namespace PlantPal.Repositories
{
    public class PlantsRepositoryDb : IPlantsRepository
    {
        private SensorDataDbContext _context;
        

        public PlantsRepositoryDb(SensorDataDbContext context)
        {
            _context = context;
        }

        public Plant Add(Plant newPlant)
        {
            newPlant.Id = null;
            _context.plants.Add(newPlant);
            _context.SaveChanges();
            return newPlant;
        }
        public Plant? Delete(int Id)
        {

        }
        public List<Plant> GetAll();
        public Plant GetById(int Id);
    }
}
