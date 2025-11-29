using DataShared.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidaStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _context.Orders.ToList();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = _context.Orders.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] Order order)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            order.CreateAt = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetItem), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Order order)
        {
            var existing = _context.Orders.Find(id);
            if (!ModelState.IsValid) return BadRequest();
            if (existing == null) return NotFound();

            existing.OrderNote = order.OrderNote;
            existing.OrderStatus = order.OrderStatus;
            existing.PaymentMethod = order.PaymentMethod;
            existing.PaymentStatus = order.PaymentStatus;
            existing.ReceiverName = order.ReceiverName;
            existing.ReceiverPhone = order.ReceiverPhone;
            existing.ShippingAddress = order.ShippingAddress;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _context.Orders.Find(id);
            if (item == null) return NotFound();
            _context.Orders.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}