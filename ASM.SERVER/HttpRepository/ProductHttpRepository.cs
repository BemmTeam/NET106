using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Extensions;
using ASM.SHARE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASM.SERVER.HttpRepository
{
    public class ProductHttpRepository : ASM.SERVER.HttpInterfaces.IProductHttp
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

        public async Task DeleteFile(string pathFile)
        {
            await client.DeleteAsync($"https://localhost:5001/api/DropboxClient/DeleteFile?path={pathFile}");

        }

        public async Task<DataJsonResult> DeleteAsync(Guid productId, string pathFile)
        {
            var result = await client.DeleteAsync($"https://localhost:5001/api/Product/?id={productId}");

            await DeleteFile(pathFile);

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

        public async Task<PagingProductDto> GetProductsAsync(PagingProductDto pagingDto)
        {
            var products = new List<Product>();
            var result = await client.PostAsync("https://localhost:5001/api/Product/Products", pagingDto.ToJsonBody());

            if (result.IsSuccessStatusCode)
            {
                var finalData = await result.Content.ReadAsStringAsync();
                var _dataResponse = JsonConvert.DeserializeObject<PagingProductDto>(finalData);

                // _dataResponse.Data = JsonConvert.DeserializeObject<List<Product>>(_dataResponse.Data.ToString());
                return _dataResponse;

            }
            return null;
        }


        public async Task<DataJsonResult> UpdateAsync(Guid id, ProductDto productDto)
        {
            var result = await client.PutAsync($"https://localhost:5001/api/Product/?id={id}", productDto.ToJsonBody());
            if (result.IsSuccessStatusCode)
            {
                return await result.ToDataJsonResultAsync();
            }
            return new DataJsonResult { IsSuccess = false, Message = "Dữ liệu không đúng định dạng" };
        }

        public async Task<DataJsonResult> UploadFile(MultipartFormDataContent content)
        {
            var response = await client.PostAsync("https://localhost:5001/api/DropboxClient/UploadFile", content);

            return await response.ToDataJsonResultAsync();
        }

        public async Task<PagingProductDto> GetListProductWithThumbImage(PagingProductDto pagingDto)
        {


            var paging = await GetProductsAsync(pagingDto);
            var products = paging.Data;


            var productTask = new List<List<Product>>();

            for (var j = 0; j < products.Count; j += 25)
            {
                productTask.Add(products.Skip(j).Take(25).ToList());
            }

            var stringImages = new List<SendPostGetThumb>();
            foreach (var item in productTask)
            {
                var content = item.Select(p => new SendPostGetThumb(p.ImageUrl)).ToJsonBody();
                var res = await client.PostAsync("https://localhost:5001/api/DropboxClient/GetThumbnail", content);

                var listImages = await res.ToDataJsonResultAsync();

                if (listImages.IsSuccess)
                {
                    stringImages.AddRange(JsonConvert.DeserializeObject<List<SendPostGetThumb>>(listImages.Data.ToString()));
                }
            }

            for (int i = 0; i < stringImages.Count; i++)
            {
                products[i].ThumbString = "data:image/jpeg;base64," + stringImages[i].Path;
            }

            paging.Data = products;
            return paging;
        }
    }
}
