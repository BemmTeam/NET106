using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Extensions;
using ASM.SHARE.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ASM.SERVER.HttpRepository
{
    public class CategoryHttpRepository : ASM.SERVER.HttpInterfaces.ICategoryHttp
    {
        private readonly HttpClient client;

        public CategoryHttpRepository(HttpClient client)
        {
            this.client = client;
        }

        public async Task<DataJsonResult> CreateAsync(CategoryDto category)
        {
            var result = await client.PostAsync("https://localhost:5001/api/Category/", category.ToJsonBody());
            return await result.ToDataJsonResultAsync();
            
        }

        public async Task<DataJsonResult> DeleteAsync(int categoryId)
        {
            var result = await client.DeleteAsync($"https://localhost:5001/api/Category/?id={categoryId}");

            return await result.ToDataJsonResultAsync();
        }

        public Task<Category> GetByIdAsync(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = new List<Category>();
            var result = await client.GetAsync("https://localhost:5001/api/Category");

            if(result.IsSuccessStatusCode)
            {
                var _dataResponse = await result.ToDataJsonResultAsync();
                if (_dataResponse.IsSuccess)
                {
                    categories = JsonConvert.DeserializeObject<List<Category>>(_dataResponse.Data.ToString());
                }
            }

            return categories;
        }

        public async Task<DataJsonResult> UpdateAsync(int id, CategoryDto category)
        {
            var result = await client.PutAsync($"https://localhost:5001/api/Category/?id={id}", category.ToJsonBody());
            if(result.IsSuccessStatusCode)
            {
                return await result.ToDataJsonResultAsync();
            }
            return new DataJsonResult { IsSuccess = false, Message = "Dữ liệu không đúng định dạng" };
        }
    }
}
