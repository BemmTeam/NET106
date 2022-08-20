using ASM.SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SHARE.Interfaces
{
    public interface ICart
    {
        Task<bool> CreateAsync(Cart cart);

        Task<bool> UpdateAsync(Cart cart);

        Task<bool> DeleteAsync(Guid cartId);

        Task<Cart> GetByIdAsync(Guid cartId);

        Task<List<Cart>> GetCartsAsync();

        Task<List<Cart>> GetListByUserIdAsync(Guid userId);
    }
}
