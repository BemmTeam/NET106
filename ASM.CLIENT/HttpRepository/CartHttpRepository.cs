using ASM.CLIENT.HttpInterfaces;
using ASM.SHARE.Dtos;
using ASM.SHARE.Extensions;
using ASM.SHARE.Interfaces;
using ASM.SHARE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASM.CLIENT.HttpRepository
{
    public class CartHttpRepository : ICartHttp
    {
        private readonly HttpClient client;

        public CartHttpRepository(HttpClient client)
        {
            this.client = client;
        }

        public async Task<DataJsonResult> CreateAsync(CartDto cartDto)
        {
            var result = await client.PostAsync("https://localhost:5001/api/Cart/", cartDto.ToJsonBody());
            return await result.ToDataJsonResultAsync();
        }

        public async Task<DataJsonResult> GetListByUserId(Guid id)
        {
            var result = await client.GetAsync($"https://localhost:5001/api/Cart/GetCartByUserId?id={id}");
            return await result.ToDataJsonResultAsync();
        }
    }
}
