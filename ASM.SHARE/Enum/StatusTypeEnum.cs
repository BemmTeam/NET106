using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.SHARE.Enum
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
}
