using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using PlantPalLib.Models;
using PlantPal.Repositories;

namespace PlantPal.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private IPlantsRepository _repository;

        public PlantsController(IPlantsRepository repository)
        {
            _repository = repository; // Singleton
        }

        // GET: api/<PlantsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Plant>> GetAll()
        {
            List<Plant> result = _repository.GetAll(); // Hent alle planter
            if (result.Count < 1) // Hvis der ikke er nogen planter
            {
                return NoContent(); // Returner 204 No Content
            }
            return Ok(result); // Returner 200 OK
        }

        // GET api/<PlantsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Plant> Get(int id)
        {
            try // Prøv at hent plante ud fra id
            {
                return Ok(_repository.GetById(id)); // Returner 200 OK
            }
            catch (ArgumentException ex) // Hvis der ikke er nogen plante med det id
            {
                return NotFound(ex.Message); // Returner 404 Not Found
            }
        }

        // POST api/<PlantsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Plant> Post([FromBody] Plant newPlant)
        {
            try // Prøv at tilføj plante
            {
                Plant createdPlant = _repository.Add(newPlant); // Tilføj plante
                return Created($"api/plants/{createdPlant.PlantId}", createdPlant); // Returner 201 Created
            }
            catch (ArgumentNullException ex) // Hvis der mangler data
            {
				return BadRequest(ex.Message); // Returner 400 Bad Request
			}
			catch (ArgumentOutOfRangeException ex) // Hvis der er ugyldige data
            {
				return BadRequest(ex.Message); // Returner 400 Bad Request
			}
			catch (ArgumentException ex) // Hvis der er ugyldige data
            {
				return BadRequest(ex.Message); // Returner 400 Bad Request
			}
        }

        // PUT api/<PlantsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Plant> Put(int id, [FromBody] Plant updates)
        {
            try // Prøv at opdater plante
            {
                Plant? updatedPlant = _repository.Update(id, updates); // Opdater plante
                return Ok(updatedPlant); // Returner 200 OK
            }
            catch (KeyNotFoundException ex) // Hvis der ikke er nogen plante med det id
            {
				return NotFound(ex.Message); // Returner 404 Not Found
			}
            catch (ArgumentNullException ex) // Hvis der mangler data
            {
                return BadRequest(ex.Message); // Returner 400 Bad Request
            }
            catch (ArgumentOutOfRangeException ex) // Hvis der er ugyldige data
            {
                return BadRequest(ex.Message); // Returner 400 Bad Request
            }
            catch (ArgumentException ex) // Hvis der er ugyldige data
            {
                return BadRequest(ex.Message); // Returner 400 Bad Request
            }
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("selected/{id}")]
        public ActionResult<Plant> PutSelected(int id)
        {
            try // Prøv at opdater plante
            {
                _repository.UpdateSelected(id); // Opdater plante
                return NoContent(); // Returner 204 No Content
            }
            catch (KeyNotFoundException ex) // Hvis der ikke er nogen plante med det id
            {
                return NotFound(ex.Message); // Returner 404 Not Found
            }
            catch (ArgumentNullException ex) // Hvis der mangler data
            {
                return BadRequest(ex.Message); // Returner 400 Bad Request
            }
            catch (ArgumentOutOfRangeException ex) // Hvis der er ugyldige data
            {
                return BadRequest(ex.Message); // Returner 400 Bad Request
            }
            catch (ArgumentException ex) // Hvis der er ugyldige data
            {
                return BadRequest(ex.Message); // Returner 400 Bad Request
            }
        }

        // DELETE api/<PlantsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Plant> Delete(int id)
        {
            if (_repository.GetById(id) == null) // Hvis der ikke er nogen plante med det id
            {
                return NotFound($"Plant with id '{id}' was not found"); // Returner 404 Not Found
            }
            Plant deletedPlant = _repository.Delete(id); // Slet plante
            return Ok($"Plant with id '{deletedPlant.PlantId}' was deleted"); // Returner 200 OK
        }
    }
}
