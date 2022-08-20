
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.SHARE.Entities
{
    public class CartDetail
    {

        [Key]
        public Guid CartDetailId { get; set; }

        [Display(Name = "Số lượng sản phẩm")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        public int Quantity { get; set; }

        [Display(Name = "Giá sản phẩm")]
        public float Price { get; set; }

        [Display(Name = "Đơn hàng")]
        public Guid CartId { get; set; }

        [ForeignKey("CartId")]
     
        public Cart Cart { get; set; }

        [Display(Name = "Sản phẩm")]
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
   
        public Product Product { get; set; }


        [NotMapped] // tự tính duoc nên không cần map vào
        public float Total { get; set; }

    }
}