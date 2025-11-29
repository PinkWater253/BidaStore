using DataShared.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidaStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _context.Posts.ToList();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = _context.Posts.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] Post post)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            post.CreateAt = DateTime.Now;
            _context.Posts.Add(post);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetItem), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Post post)
        {
            var existing = _context.Posts.Find(id);
            if (!ModelState.IsValid) return BadRequest();
            if (existing == null) return NotFound();

            existing.Title = post.Title;
            existing.Img = post.Img;
            existing.IsApproved = post.IsApproved;
            existing.Content = post.Content;
            existing.UpdateAt = DateTime.Now;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _context.Posts.Find(id);
            if (item == null) return NotFound();
            _context.Posts.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}