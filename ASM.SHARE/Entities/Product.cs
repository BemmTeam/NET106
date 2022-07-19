

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.SHARE.Entities 
{
    public class Product 
    {   
        [Key]
        public Guid ProductId {get;set;}

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên món ăn")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        [StringLength(100 , ErrorMessage = "{0} chỉ được nhập từ {2} đến {1} ký tự" , MinimumLength = 4)]
        public string Name {get;set;}
        
        [Display(Name = "Số lượng")]
   
        public int Quantity {get;set;}

        [Display(Name = "Giá món ăn")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        [Column(TypeName = "money")]
        public float Price {get;set;}

        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả")]
        public string Desc {get;set;}

        [Display(Name = "Hình ảnh")]
        public string ImageUrl {get;set;}
        
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        [StringLength(200 , ErrorMessage = "{0} chỉ được nhập từ {2} đến {1} ký tự" , MinimumLength = 4)]
        public string Address {get;set;}


        // khóa ngoại
        public int CategoryId {get;set;}
        [ForeignKey("CategoryId")]
        public  Category Category {get;set;}

      

    }
}