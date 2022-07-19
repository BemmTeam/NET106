using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
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

        public Task<bool> CreateAsync(CategoryDto category)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int categoryId)
        {
            throw new System.NotImplementedException();
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
                var finalData = await result.Content.ReadAsStringAsync();
                var _dataResponse = JsonConvert.DeserializeObject<DataJsonResult>(finalData);
                if(_dataResponse.IsSuccess)
                {
                    categories = JsonConvert.DeserializeObject<List<Category>>(_dataResponse.Data.ToString());
                }
            }

            return categories;
        }

        public Task<bool> UpdateAsync(int id, CategoryDto category)
        {
            throw new System.NotImplementedException();
        }
    }
}
