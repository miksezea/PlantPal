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
            _repository = repository;
        }

        // GET: sensordatas
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<SensorData>> GetAll()
        {
            List<SensorData> result = _repository.GetAll();
            if (result.Count < 1)
            {
                return NoContent();
            }
            return Ok(result);
        }

        // GET api/{id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<SensorData> Get(int id)
        {
            try
            {
                return Ok(_repository.GetById(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }                       
        }

        // POST: sensordatas
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<SensorData> Post([FromBody] SensorData newData)
        {
            try
            {
                SensorData createdData = _repository.Add(newData);
                return Created($"api/sensordatas/{createdData.Id}", createdData);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: sensordatas/{id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<SensorData> Delete(int id)
        {
           if (_repository.GetById(id) == null)
            {
                return NotFound($"Sensor data with id '{id}' was not found");
            }
            SensorData deletedData = _repository.Delete(id);
            return Ok($"Sensordata with id '{deletedData.Id}' was deleted");
        }
    }
}
