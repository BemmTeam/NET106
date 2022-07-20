using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.SHARE.Entities 
{
    public class Category
    {
        [Key]
        [DisplayName("Id danh mục")]
        public int CategoryId {get;set;}

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Tên danh mục")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        [StringLength(100 , ErrorMessage = "{0} chỉ được nhập từ {2} đến {1} ký tự" , MinimumLength = 4)]
        public string Name {get;set;}

        [Column(TypeName = "ntext")]
     
        [DisplayName("Mô tả")]

        public string Desc {get;set;}

        [DisplayName("Hình ảnh")]

        public string ImageUrl {get;set;}

        public  ICollection<Product> Products {get;set;}
        

   
    }
}