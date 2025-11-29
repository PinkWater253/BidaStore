using DataShared.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidaStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _context.Carts.ToList();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = _context.Carts.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] Cart cart)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetItem), new { id = cart.Id }, cart);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Cart cart)
        {
            var existing = _context.Carts.Find(id);
            if (!ModelState.IsValid) return BadRequest();
            if (existing == null) return NotFound();

            existing.ProductId = cart.ProductId;
            existing.CustomerId = cart.CustomerId;
            existing.Quantity = cart.Quantity;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _context.Carts.Find(id);
            if (item == null) return NotFound();
            _context.Carts.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}