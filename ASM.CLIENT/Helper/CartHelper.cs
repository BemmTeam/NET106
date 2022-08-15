using ASM.SHARE.Entities;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.CLIENT.Helper
{
    public class CartHelper
    {

        private readonly IJSRuntime jsRuntime;

        public CartHelper(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task InsertCartAsync(CartDetail cartDetail)
        {
            await jsRuntime.InvokeVoidAsync("Cart.InsertCart", cartDetail);
        }

        public async Task DeleteCartAsync(Guid id)
        {
            await jsRuntime.InvokeVoidAsync("Cart.DeleteCart", id);
        }

        public async Task<List<CartDetail>> GetListCartAsync()
        {
           var data =  await jsRuntime.InvokeAsync<string>("Cart.GetList");
            var List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CartDetail>>(data);
            return List;
        }
    }
}
