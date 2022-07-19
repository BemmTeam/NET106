using ASM.SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SHARE.Interfaces
{
    public interface IProduct
    {

        Task<bool> CreateAsync(Product product);

        Task<bool> UpdateAsync(Product product);

        Task<bool> DeleteAsync(Guid productId);

        Task<List<Product>> GetProductsAsync(); 

        Task<Product> GetProductByIdAsync(Guid productId);

    }
}
