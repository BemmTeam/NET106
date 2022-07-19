using ASM.SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SHARE.Interfaces
{
    public interface ICart
    {
        Task<bool> Create(Cart cart);

        Task<bool> Update(Cart cart);

        Task<bool> Delete(Guid cartId);

        Task<Cart> GetById(Guid cartId);

        Task<List<Cart>> GetCarts();
    }
}
