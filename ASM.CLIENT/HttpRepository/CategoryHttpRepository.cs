using ASM.CLIENT.HttpInterfaces;
using ASM.SHARE.Entities;
using ASM.SHARE.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASM.CLIENT.HttpRepository
{
    public class CategoryHttpRepository : ICategoryHttp
    {

        private HttpClient client { get; set; }
        public CategoryHttpRepository(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<Category>> GetCategories()
        {
            var categories = new List<Category>();
            var result = await client.GetAsync("https://localhost:5001/api/Category");

            if (result.IsSuccessStatusCode)
            {
                var _dataResponse = await result.ToDataJsonResultAsync();
                if (_dataResponse.IsSuccess)
                {
                    categories = JsonConvert.DeserializeObject<List<Category>>(_dataResponse.Data.ToString());
                }
            }

            return categories;
        }
    }
}
