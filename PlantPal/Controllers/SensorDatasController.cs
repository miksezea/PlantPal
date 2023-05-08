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
        private readonly SensorDatasRepository _repository;
        public SensorDatasController(SensorDatasRepository repository)
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
                SensorData result = _repository.GetById(id);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }                       
        }

        // POST: sensordatas
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("add_item")]
        public ActionResult<SensorData> Create([FromBody] SensorData newData)
        {
            try
            {
                SensorData createdData = _repository.Add(newData);
                return Created($"api/sensordatas/{createdData.Id}", createdData);
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: sensordatas/{id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Ok($"Sensordata with id '{id}' was deleted");
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
