using System.ComponentModel.DataAnnotations;

namespace BidaStore.Client.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        [MaxLength(100)]
        public string? Title { get; set; }
        [MaxLength(500, ErrorMessage = "Không quá 500 kí tự")]
        public string? Content { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        public int? Price { get; set; }
        [Range(0.0, 5.0, ErrorMessage = "Đánh giá phải từ 0.0 đến 5.0")]
        public double? Rate { get; set; }
        public string? Img { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? CategoryId { get; set; }
    }
}
