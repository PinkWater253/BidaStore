using DataShared.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidaStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _context.Contacts.ToList();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = _context.Contacts.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] Contact contact)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetItem), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Contact contact)
        {
            var existing = _context.Contacts.Find(id);
            if (!ModelState.IsValid) return BadRequest();
            if (existing == null) return NotFound();

            existing.FullName = contact.FullName;
            existing.Email = contact.Email;
            existing.Phone = contact.Phone;
            existing.Subject = contact.Subject;
            existing.Message = contact.Message;
            existing.IsResolved = contact.IsResolved;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _context.Contacts.Find(id);
            if (item == null) return NotFound();
            _context.Contacts.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}