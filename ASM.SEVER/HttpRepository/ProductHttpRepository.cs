using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Extensions;
using ASM.SHARE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

        public async Task<DataJsonResult> DeleteAsync(Guid productId)
        {
            var result = await client.DeleteAsync($"https://localhost:5001/api/Product/?id={productId}");

            return await result.ToDataJsonResultAsync();
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
            var response =  await client.PostAsync("https://localhost:5001/api/DropboxClient/UploadFile", content);

            return await response.ToDataJsonResultAsync();
        }

        public async Task<List<ASM.SHARE.Entities.Product>> GetListProductWithThumbImage()
        {
            var products =  await GetProductsAsync();
            var paths = new List<SendPostGetThumb>();
            foreach(var product in products)
            {
                paths.Add(new SendPostGetThumb(product.ImageUrl));
            }
            var objData = new
            {
                entries = paths
            };
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(objData), Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "sl.BMtCiKehvakPNgiBQkZ6Kj4SgISBvM-UAmGjzKmiVMvG9OB64mJS4wpZxUlkUO8Owx72j5d51wvOGCnu1ooz6-uHmYRf4y9nZdhienPQCMfcW5cyL5IPDV4GikTr4FQuYtQTWjjA8UM");

            var response = await client.PostAsync("https://content.dropboxapi.com/2/files/get_thumbnail_batch", content);

            var entrie = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseThumb>(await response.Content.ReadAsStringAsync());

            for (int i = 0; i < entrie.entries.Count; i++)
            {
                products[i].ThumbString = "data:image/jpeg;base64," + entrie.entries[i].thumbnail;
            }

            return products;
        }
    }
}
