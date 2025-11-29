using DataShared.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidaStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _context.Customers.ToList();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = _context.Customers.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            customer.RegisteredAt = DateTime.Now;
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetItem), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Customer customer)
        {
            var existing = _context.Customers.Find(id);
            if (!ModelState.IsValid) return BadRequest();
            if (existing == null) return NotFound();

            existing.FirstName = customer.FirstName;
            existing.LastName = customer.LastName;
            existing.Email = customer.Email;
            existing.Phone = customer.Phone;
            existing.Address = customer.Address;
            existing.Img = customer.Img;
            existing.IsActive = customer.IsActive;
            existing.Role = customer.Role;
            existing.UpdateAt = DateTime.Now;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _context.Customers.Find(id);
            if (item == null) return NotFound();
            _context.Customers.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}