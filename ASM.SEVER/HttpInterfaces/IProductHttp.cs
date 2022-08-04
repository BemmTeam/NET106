using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASM.SEVER.HttpInterfaces
{
    public interface IProductHttp
    {
        Task<DataJsonResult> CreateAsync(ProductDto productDto);

        Task<DataJsonResult> UpdateAsync(Guid id, ProductDto productDto);

        Task<DataJsonResult> DeleteAsync(Guid productId);

        Task<DataJsonResult> UploadFile(MultipartFormDataContent content);

        Task<Product> GetByIdAsync(Guid productId);

        Task<List<Product>> GetProductsAsync();

        Task<List<ASM.SHARE.Entities.Product>> GetListProductWithThumbImage();

    }
}
