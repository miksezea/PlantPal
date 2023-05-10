using PlantPalLib.Models;

namespace PlantPal.Repositories
{
    public interface IPlantsRepository
    {
        Plant Add(Plant newPlant);
        Plant Delete(int Id);
        List<Plant> GetAll();
        Plant GetById(int Id);
    }
}
