using ASM.SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SHARE.Interfaces
{
    public interface ICartDetail
    {
        Task<bool> CreateAsync(CartDetail cartDetail);

        Task<bool> UpdateAsync(CartDetail cartDetail);

        Task<bool> DeleteAsync(Guid cartDetailId);

        Task<CartDetail> GetByIdAsync(Guid cartDetailId);

        Task<List<CartDetail>> GetCartDetailsAsync();

        Task<List<CartDetail>> GetCartDetailByCartIdAsync(Guid id);
    }
}
