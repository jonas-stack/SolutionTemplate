using Microsoft.AspNetCore.Mvc;
using Service;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FruitController : ControllerBase
    {
        private readonly FruitService _fruitService;

        public FruitController(FruitService fruitService)
        {
            _fruitService = fruitService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Fruit>> GetAll() => Ok(_fruitService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Fruit> GetById(int id)
        {
            var fruit = _fruitService.GetById(id);
            if (fruit == null) return NotFound();
            return Ok(fruit);
        }

        [HttpPost]
        public ActionResult Add(Fruit fruit)
        {
            _fruitService.Add(fruit);
            return CreatedAtAction(nameof(GetById), new { id = fruit.Id }, fruit);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Fruit fruit)
        {
            if (id != fruit.Id) return BadRequest();
            var existingFruit = _fruitService.GetById(id);
            if (existingFruit == null) return NotFound();
            _fruitService.Update(fruit);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingFruit = _fruitService.GetById(id);
            if (existingFruit == null) return NotFound();
            _fruitService.Delete(id);
            return NoContent();
        }
    }
}