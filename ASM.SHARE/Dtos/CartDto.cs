using ASM.SHARE.Entities;
using ASM.SHARE.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM.SHARE.Dtos
{
    public class CartDto
    {
        public Guid CartId { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime Completed { get; set; }

        public string Address { get; set; }

        public StatusType Status { get; set; }

        [Display(Name = "Tổng tiền")]
        public float Total { get; set; }

        [Display(Name = "Danh sách đơn hàng chi tiết")]

        public List<CartDetail> CartDetails { get; set; }


        // Khóa ngoại
        public Guid UserId { get; set; }

    }
}
