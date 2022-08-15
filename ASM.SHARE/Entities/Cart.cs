
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.SHARE.Entities
{


    public class Cart
    {
        public enum StatusType
        {
            [Display(Name = "Hoàn Thành")]
            Success = 1,

            [Display(Name = "Đơn hàng bị hủy")]
            Cancel = 2,

            [Display(Name = "Đang giao hàng")]
            Shipping = 3,
        }
        [Key]
        public Guid CartId { get; set; }

        [Display(Name = "Ngày đặt hàng")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Thời gian hoàn thành")]
        public DateTime Completed { get; set; }



        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Địa chỉ giao hàng")]
        [Required(ErrorMessage = "{0} là phải nhập")]
        [StringLength(200, ErrorMessage = "{0} chỉ được nhập từ {2} đến {1} ký tự", MinimumLength = 4)]
        public string Address { get; set; }

        [Display(Name = "Trạng thái")]
        public StatusType Status { get; set; }

        [Display(Name = "Tổng tiền")]
        public float Total { get; set; }

        [Display(Name = "Danh sách đơn hàng chi tiết")]
        public List<CartDetail> CartDetails { get; set; }

        // Khóa ngoại
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        [Display(Name = "Khách hàng")]
        public User User { get; set; }


    }
}