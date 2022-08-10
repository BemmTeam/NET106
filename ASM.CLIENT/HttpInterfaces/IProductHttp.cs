using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.CLIENT.HttpInterfaces
{
    public interface IProductHttp
    {
        Task<List<Product>> GetProductsAsync();

        Task<PagingProductDto> GetListProductWithThumbImage(PagingProductDto pagingDto);

        Task<Product> GetProduct(Guid id);
    }
}
