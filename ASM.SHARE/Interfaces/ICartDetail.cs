using ASM.SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SHARE.Interfaces
{
    public interface ICartDetail
    {
        Task<bool> Create(CartDetail cartDetail);

        Task<bool> Update(CartDetail cartDetail);

        Task<bool> Delete(Guid cartDetailId);

        Task<CartDetail> GetById(Guid cartDetailId);

        Task<List<CartDetail>> GetCartDetails();
    }
}
