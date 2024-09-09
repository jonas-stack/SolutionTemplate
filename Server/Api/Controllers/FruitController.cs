using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Fruit = DataAccess.Fruit;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FruitController : ControllerBase
    {
        private readonly MyDbContext _context;

        public FruitController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Fruit>> GetAll() => Ok(_context.Fruits.ToList());

        [HttpGet("{id}")]
        public ActionResult<Fruit> GetById(int id)
        {
            var fruit = _context.Fruits.Find(id);
            if (fruit == null) return NotFound();
            return Ok(fruit);
        }

        [HttpPost]
        public ActionResult Add(Fruit fruit)
        {
            _context.Fruits.Add(fruit);
            _context.SaveChanges();
            return Ok(new { id = fruit.Id });
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Fruit fruit)
        {
            if (id != fruit.Id) return BadRequest();
            var existingFruit = _context.Fruits.Find(id);
            if (existingFruit == null) return NotFound();
            _context.Entry(existingFruit).CurrentValues.SetValues(fruit);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingFruit = _context.Fruits.Find(id);
            if (existingFruit == null) return NotFound();
            _context.Fruits.Remove(existingFruit);
            _context.SaveChanges();
            return Ok(new { id = id });
        }
    }
}