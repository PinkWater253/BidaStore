using System.ComponentModel.DataAnnotations;

namespace BidaStore.Client.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Vui lòng nhập email")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage ="Vui lòng nhập tiêu đề")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        public string Message { get; set; } = string.Empty;
    }
}
