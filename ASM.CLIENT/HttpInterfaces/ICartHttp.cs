using ASM.SHARE.Dtos;
using ASM.SHARE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.CLIENT.HttpInterfaces
{
    public interface ICartHttp
    {

        Task<DataJsonResult> CreateAsync(CartDto cartDto);
    }
}
