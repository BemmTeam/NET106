using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SHARE.Interfaces
{
    public interface IProduct
    {

        Task<bool> CreateAsync(Product product);


        Task<bool> CreateManyAsync(List<Product> products);

        Task<bool> UpdateAsync(Guid id, Product product);

        Task<bool> DeleteAsync(Guid productId);

        Task<List<Product>> GetProductsAsync();
        Task<PagingProductDto> GetProductsAsync(PagingProductDto paging);
        Task<Product> GetProductByIdAsync(Guid productId);

    }
}
