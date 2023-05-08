using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using PlantPalLib.Models;
using PlantPal.Repositories;

namespace PlantPal.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class SensorDatasController : ControllerBase
    {
        private readonly SensorDatasRepository _repository;
        public SensorDatasController(SensorDatasRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<SensorDatasController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<SensorData>> GetAll()
        {
            List<SensorData> result = _repository.GetAll();

        }

        // GET api/<SensorDatasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SensorDatasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SensorDatasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SensorDatasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
