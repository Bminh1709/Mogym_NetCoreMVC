using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MOGYM.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn chưa điền tên")]
        public string Name { get; set; } = "Không tên";

        [Required(ErrorMessage = "Bạn chưa điền Gmail"), EmailAddress(ErrorMessage = "Định dạng gmail chưa chính xác")]
        public string Gmail { get; set; }

        [Required(ErrorMessage = "Bạn chưa điền mật khẩu"), MinLength(8, ErrorMessage = "Ít nhất 8 ký tự")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bạn chưa điền số điện thoại"), Phone(ErrorMessage = "Định dạng số điện thoại chưa chính xác")]
        public string PhoneNumber { get; set; }
        public DateTime JoinedDate { get; set; } = DateTime.Now;

        public string? Avatar { get; set; }
        public BranchModel? Branch { get; set; }
    }

}
