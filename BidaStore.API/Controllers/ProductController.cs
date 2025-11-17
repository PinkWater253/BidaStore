using BidaStore.API.Models; // Đảm bảo bạn đã tham chiếu đến BidaStore.Shared nếu dùng cách 2, hoặc giữ nguyên nếu dùng cách 1
using BidaStore.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // GET: api/Product
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products.OrderByDescending(p => p.Title).ToList();
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            // Thêm một số giá trị mặc định nếu cần
            product.CreateAt = DateTime.Now;

            _context.Products.Add(product);
            _context.SaveChanges();

            // Trả về sản phẩm đã tạo cùng với action GetProduct
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("Product ID mismatch");
            }

            var existingProduct = _context.Products.Find(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            // Cập nhật các thuộc tính từ product gửi lên
            existingProduct.Title = product.Title;
            existingProduct.Content = product.Content;
            existingProduct.Price = product.Price;
            existingProduct.Img = product.Img;
            existingProduct.Rate = product.Rate;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.UpdateAt = DateTime.Now; // Cập nhật thời gian

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Xử lý trường hợp có lỗi tương tranh (concurrency)
                if (!_context.Products.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(existingProduct); // Trả về sản phẩm đã cập nhật
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(new { message = "Product deleted successfully" }); // Trả về thông báo thành công
        }
    }
}