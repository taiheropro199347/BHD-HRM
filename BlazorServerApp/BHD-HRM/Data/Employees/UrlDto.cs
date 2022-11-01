using System.ComponentModel.DataAnnotations;

namespace BHD_HRM.Data.Employees
{
    public class UrlDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool? Status { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Email")]
        public string Email { get; set; }
    }
}
