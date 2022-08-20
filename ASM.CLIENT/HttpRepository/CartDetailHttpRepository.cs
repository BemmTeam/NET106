using ASM.CLIENT.HttpInterfaces;
using ASM.SHARE.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASM.CLIENT.HttpRepository
{
    public class CartDetailHttpRepository : ICartDetailHttp
    {
        private readonly HttpClient client;

        public CartDetailHttpRepository(HttpClient client)
        {
            this.client = client;
        }
        public async Task<List<CartDetail>> GetCartByCartId(Guid id)
        {
            var result = await client.GetAsync($"https://localhost:5001/api/CartDetail/CartDetailByCartId?id={id}");
            var finalData = await result.Content.ReadAsStringAsync();
            var _dataResponse = JsonConvert.DeserializeObject<List<CartDetail>>(finalData);
            return _dataResponse;
        }
    }
}
