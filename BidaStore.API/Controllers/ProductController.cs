using BidaStore.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BidaStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products.OrderByDescending(p => p.Title).ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
