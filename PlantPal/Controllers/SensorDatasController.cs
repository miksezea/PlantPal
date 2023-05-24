using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using PlantPalLib.Models;
using PlantPal.Repositories;

namespace PlantPal.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/sensordatas")]
    [ApiController]
    public class SensorDatasController : ControllerBase
    {
        private ISensorDatasRepository _repository;

        public SensorDatasController(ISensorDatasRepository repository)
        {
            _repository = repository; // Singleton
        }

        // GET: sensordatas
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<SensorData>> GetAll()
        {
            List<SensorData> result = _repository.GetAll(); // Hent alle sensordata
            if (result.Count < 1) // Hvis der ikke er nogen sensordata
            {
                return NoContent(); // Returner 204 No Content
            }
            return Ok(result); // Returner 200 OK
        }

        // GET api/{id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<SensorData> Get(int id)
        {
            try // Prøv at hent sensordata ud fra id
            {
                return Ok(_repository.GetById(id)); // Returner 200 OK
            }
            catch (ArgumentException ex) // Hvis der ikke er nogen sensordata med det id
            {
                return NotFound(ex.Message); // Returner 404 Not Found
            }                       
        }

        // POST: sensordatas
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<SensorData> Post([FromBody] SensorData newData)
        {
            try // Prøv at tilføj sensordata
            {
                SensorData createdData = _repository.Add(newData); // Tilføj sensordata
                return Created($"api/sensordatas/{createdData.Id}", createdData); // Returner 201 Created
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message); // Returner 400 Bad Request
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message); // Returner 400 Bad Request
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Returner 400 Bad Request
            }
        }

        // DELETE: sensordatas/{id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<SensorData> Delete(int id)
        {
           if (_repository.GetById(id) == null) // Hvis der ikke er nogen sensordata med det id
            {
                return NotFound($"Sensor data with id '{id}' was not found"); // Returner 404 Not Found
            }
            SensorData deletedData = _repository.Delete(id); // Slet sensordata
            return Ok($"Sensordata with id '{deletedData.Id}' was deleted"); // Returner 200 OK
        }
    }
}
