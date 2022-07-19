using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.SHARE.Entities 
{
    public class Category
    {
        [Key]
        public int CategoryId {get;set;}

        [Display(Name = "Tên danh mục")]
        [Column(TypeName = "nvarchar(100)")]
    
        [Required(ErrorMessage = "{0} là phải nhập")]
        [StringLength(100 , ErrorMessage = "{0} chỉ được nhập từ {2} đến {1} ký tự" , MinimumLength = 4)]
        public string Name {get;set;}

        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả")]
        public string Desc {get;set;}

        [Display(Name = "Hình ảnh")]
        public string ImageUrl {get;set;}

        public  ICollection<Product> Products {get;set;}
        

   
    }
}