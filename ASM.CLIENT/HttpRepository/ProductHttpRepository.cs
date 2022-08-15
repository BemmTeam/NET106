using ASM.CLIENT.HttpInterfaces;
using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Extensions;
using ASM.SHARE.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASM.CLIENT.HttpRepository
{
    public class ProductHttpRepository : IProductHttp
    {
        private HttpClient client { get; set; }

        public ProductHttpRepository(HttpClient client)
        {
            this.client = client;
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

        public async Task<PagingProductDto> GetListProductWithThumbImage(PagingProductDto pagingDto)
        {


            var paging = await GetProductsAsync(pagingDto);
            var products = paging.Data;


            var productTask = new List<List<Product>>();

            for (var j = 0; j < products.Count; j += 25)
            {
                productTask.Add(products.Skip(j).Take(25).ToList());
            }

            var stringImages = new List<SHARE.DropBox.Dtos.SendPostGetThumb>();
            foreach (var item in productTask)
            {
                var content = item.Select(p => new SHARE.DropBox.Dtos.SendPostGetThumb(p.ImageUrl)).ToJsonBody();

                var listImages = await GetThumb(content);

                if (listImages.IsSuccess)
                {
                    stringImages.AddRange(JsonConvert.DeserializeObject<List<SHARE.DropBox.Dtos.SendPostGetThumb>>(listImages.Data.ToString()));
                }
            }

            for (int i = 0; i < stringImages.Count; i++)
            {
                products[i].ThumbString = "data:image/jpeg;base64," + stringImages[i].Path;
            }

            paging.Data = products;
            return paging;
        }

        private async Task<DataJsonResult> GetThumb(StringContent content)
        {
            var res = await client.PostAsync("https://localhost:5001/api/DropboxClient/GetThumbnail", content);

            var listImages = await res.ToDataJsonResultAsync();
            return listImages;

        }

        public async Task<Product> GetProduct(System.Guid id)
        {
            var product = new Product();
            var result = await client.GetAsync($"https://localhost:5001/api/Product/{id}");

            var response = await result.ToDataJsonResultAsync();
            if (response.IsSuccess)
            {
                product = JsonConvert.DeserializeObject<Product>(response.Data.ToString());
            }
            if (product != null)
            {


                var res = await client.GetAsync($"https://localhost:5001/api/DropboxClient/GetAThumbnail?path={product.ImageUrl}");
                var a = await res.Content.ReadAsStringAsync();
                product.ThumbString = a;                //var res = await GetThumb(content);
                //if (res.IsSuccess)
                //{
                //    product.ThumbString = JsonConvert.DeserializeObject<List<SHARE.DropBox.Dtos.SendPostGetThumb>>(res.Data.ToString())[0].Path;
                //}
            }
            return product;

        }
    }
}
