using PlantPalLib.Models;

namespace PlantPal.Repositories
{
    public interface IPlantsRepository
    {
        Plant Add(Plant newPlant); // Tilføj plante
        Plant Delete(int PlantId); // Slet plante
        List<Plant> GetAll(); // Hent alle planter
        Plant GetById(int PlantId); // Hent plante ud fra Id
        Plant Update(int PlantId, Plant updates); // Opdater plante
        Plant UpdateSelected(int PlantId);
    }
}
