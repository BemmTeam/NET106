

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.SHARE.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên món ăn")]
        [DisplayName("Tên món ăn")]

        [Required(ErrorMessage = "{0} là phải nhập")]
        [StringLength(100, ErrorMessage = "{0} chỉ được nhập từ {2} đến {1} ký tự", MinimumLength = 4)]

        public string Name { get; set; }

        [Display(Name = "Số lượng")]
        [DisplayName("Số lượng")]

        public int Quantity { get; set; }

        [Display(Name = "Giá món ăn")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        [Column(TypeName = "money")]
        [DisplayName("Giá món ăn")]

        public float Price { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả")]
        [DisplayName("Mô tả")]

        public string Desc { get; set; }

        [Display(Name = "Hình ảnh")]
        [Column(TypeName = "varchar(200)")]
        [DisplayName("Hình ảnh")]

        public string ImageUrl { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Địa chỉ")]
        [DisplayName("Địa chỉ")]

        [Required(ErrorMessage = "{0} là phải nhập")]
        [StringLength(200, ErrorMessage = "{0} chỉ được nhập từ {2} đến {1} ký tự", MinimumLength = 4)]
        public string Address { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Display(Name = "QR Code")]
        [DisplayName("QR Code")]

        public string QrCodeUrl { get; set; }


        public DateTime? CreatedDate { get; set; }

        // khóa ngoại
        [Required(ErrorMessage = "Danh mục chưa chọn")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        [NotMapped]
        public string ThumbString { get; set; }


    }
}