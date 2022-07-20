using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Extensions;
using ASM.SHARE.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ASM.SEVER.HttpRepository
{
    public class CategoryHttpRepository : ASM.SEVER.HttpInterfaces.ICategoryHttp
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

        public Task<DataJsonResult> UpdateAsync(int id, CategoryDto category)
        {
            throw new System.NotImplementedException();
        }
    }
}
