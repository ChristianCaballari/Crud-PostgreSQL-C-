using Microsoft.AspNetCore.Mvc;
using postgreSQL.Model;
using postgreSQL.Repositories;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace postgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private  ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository) { 
        _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok( await _carRepository.GetAllCart());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _carRepository.GetCarDetails(id));
        }

      

        // POST api/<CarsController>
        [HttpPost]
        public async Task<IActionResult>CreatedCar([FromBody] Car car)
        {
            if (car == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _carRepository.InsertCar(car);
            return Created("Created", created);
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Car car)
        {
            if (car == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _carRepository.UpdateCar(car,id);
            return Ok("Updated");
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _carRepository.DeleteCar(new Car { Id = id });

            return Ok("Delected");
        }
    }
}
