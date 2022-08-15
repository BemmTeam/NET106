using System;
using System.ComponentModel.DataAnnotations;

namespace ASM.SHARE.Dtos
{
    public class CartDto
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

        public DateTime CreatedDate { get; set; }

        public DateTime Completed { get; set; }

        public string Address { get; set; }

        public StatusType Status { get; set; }

        public float Total { get; set; }

        // Khóa ngoại
        public Guid UserId { get; set; }

    }
}
