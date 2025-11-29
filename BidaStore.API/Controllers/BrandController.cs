using DataShared.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidaStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BrandController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _context.Brands.ToList();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = _context.Brands.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetItem), new { id = brand.Id }, brand);
        }
    }
}
