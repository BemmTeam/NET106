
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.SHARE.Entities
{


    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [DisplayName("UserName")]

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "{0} không đúng định dạng")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        [DisplayName("Email")]

        public string Email { get; set; }


        [Display(Name = "Họ và tên")]
        [DisplayName("Họ và tên")]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        [StringLength(100, ErrorMessage = "{0} chỉ được nhập từ {2} đến {1} ký tự", MinimumLength = 4)]
        public string FullName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Địa chỉ")]
        [DisplayName("Địa chỉ")]

        [Required(ErrorMessage = "{0} là phải nhập")]
        [StringLength(200, ErrorMessage = "{0} chỉ được nhập từ {2} đến {1} ký tự", MinimumLength = 4)]
        public string Address { get; set; }

        [Display(Name = "Mật khẩu")]
        [DisplayName("Mật khẩu")]

        [Required(ErrorMessage = "{0} là phải nhập")]
        public string Password { get; set; }

        [DisplayName("Là quản trị")]

        public bool IsAdmin { get; set; }


    }
}