using ASM.SHARE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
