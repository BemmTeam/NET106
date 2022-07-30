using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SHARE.Interfaces
{
    public interface IProduct
    {

        Task<bool> CreateAsync(ProductDto product);

        Task<bool> UpdateAsync(Guid id,ProductDto product);

        Task<bool> DeleteAsync(Guid productId);

        Task<List<Product>> GetProductsAsync(); 

        Task<Product> GetProductByIdAsync(Guid productId);

    }
}
