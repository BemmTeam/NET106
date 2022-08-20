using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.CLIENT.HttpInterfaces
{
    public interface ICartDetailHttp
    {


        Task<List<CartDetail>> GetCartByCartId(Guid id);

    }
}
