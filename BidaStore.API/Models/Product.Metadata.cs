using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BidaStore.API.Models
{
    // Lớp partial này vẫn giữ nguyên
    [ModelMetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
    }

    // Lớp metadata này CHỈ chứa các thuộc tính cần validation
    public class ProductMetadata
    {
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        [MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(500, ErrorMessage ="Không quá 500 kí tự")]
        public string? Content { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        public int? Price { get; set; }

        [Range(0.0, 5.0, ErrorMessage = "Đánh giá phải từ 0.0 đến 5.0")]
        public double? Rate { get; set; }
    }
}