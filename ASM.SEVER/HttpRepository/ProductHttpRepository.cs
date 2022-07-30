using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Extensions;
using ASM.SHARE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASM.SEVER.HttpRepository
{
    public class ProductHttpRepository : ASM.SEVER.HttpInterfaces.IProductHttp
    {
        private HttpClient client;

        public ProductHttpRepository(HttpClient client)
        {
            this.client = client;
        }

        public async Task<DataJsonResult> CreateAsync(ProductDto productDto)
        {
            var result = await client.PostAsync("https://localhost:5001/api/Product/", productDto.ToJsonBody());
            return await result.ToDataJsonResultAsync();
        }

        public Task<DataJsonResult> DeleteAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = new List<Product>();
            var result = await client.GetAsync("https://localhost:5001/api/Product");

            if (result.IsSuccessStatusCode)
            {
                var _dataResponse = await result.ToDataJsonResultAsync();
                if (_dataResponse.IsSuccess)
                {
                    products = JsonConvert.DeserializeObject<List<Product>>(_dataResponse.Data.ToString());
                }
            }

            return products;
        }

        public Task<DataJsonResult> UpdateAsync(Guid id, ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public async Task<DataJsonResult> UploadFile(MultipartFormDataContent content)
        {
            var response =  await client.PostAsync("https://localhost:5001/api/Product/UploadFile",content);

            return await response.ToDataJsonResultAsync();
        }
    }
}
