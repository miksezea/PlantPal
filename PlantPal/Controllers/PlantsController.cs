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
            _repository = repository;
        }

        // GET: api/<PlantsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Plant>> GetAll()
        {
            List<Plant> result = _repository.GetAll();
            if (result.Count < 1)
            {
                return NoContent();
            }
            return Ok(result);
        }

        // GET api/<PlantsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Plant> Get(int id)
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

        // POST api/<PlantsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Plant> Post([FromBody] Plant newPlant)
        {
            try
            {
                Plant createdPlant = _repository.Add(newPlant);
                return Created($"api/plants/{createdPlant.PlantId}", createdPlant);
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

        // PUT api/<PlantsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Plant> Put(int id, [FromBody] Plant updates)
        {
            try
            {
                Plant? updatedPlant = _repository.Update(id, updates);
                return Ok(updatedPlant);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
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

        // DELETE api/<PlantsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Plant> Delete(int id)
        {
            if (_repository.GetById(id) == null)
            {
                return NotFound($"Plant with id '{id}' was not found");
            }
            Plant deletedPlant = _repository.Delete(id);
            return Ok($"Plant with id '{deletedPlant.PlantId}' was deleted");
        }
    }
}
