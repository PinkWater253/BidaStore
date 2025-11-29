using DataShared.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidaStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderDetailController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _context.OrderDetails.ToList();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = _context.OrderDetails.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] OrderDetail detail)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.OrderDetails.Add(detail);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetItem), new { id = detail.Id }, detail);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] OrderDetail detail)
        {
            var existing = _context.OrderDetails.Find(id);
            if (!ModelState.IsValid) return BadRequest();
            if (existing == null) return NotFound();

            existing.OrderId = detail.OrderId;
            existing.ProductId = detail.ProductId;
            existing.Quantity = detail.Quantity;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _context.OrderDetails.Find(id);
            if (item == null) return NotFound();
            _context.OrderDetails.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}