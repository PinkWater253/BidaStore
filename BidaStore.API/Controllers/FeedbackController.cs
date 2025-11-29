using DataShared.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidaStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FeedbackController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _context.Feedbacks.ToList();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = _context.Feedbacks.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] Feedback feedback)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            feedback.CreateAt = DateTime.Now;
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetItem), new { id = feedback.Id }, feedback);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Feedback feedback)
        {
            var existing = _context.Feedbacks.Find(id);
            if (!ModelState.IsValid) return BadRequest();
            if (existing == null) return NotFound();

            existing.Comment = feedback.Comment;
            existing.Rating = feedback.Rating;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _context.Feedbacks.Find(id);
            if (item == null) return NotFound();
            _context.Feedbacks.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}