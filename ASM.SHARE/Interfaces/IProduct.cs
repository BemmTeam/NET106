using ASM.SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SHARE.Interfaces
{
    public interface IProduct
    {

        Task<bool> Create(Product product);

        Task<bool> Update(Product product);

        Task<bool> Delete(Guid productId);

        Task<List<Product>> GetProducts(); 

        Task<Product> GetProductById(Guid productId);

    }
}
