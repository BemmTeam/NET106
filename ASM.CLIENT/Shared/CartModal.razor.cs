using ASM.CLIENT.Helper;
using ASM.SHARE.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.CLIENT.Shared
{
    public partial class CartModal
    {
        [Inject] private IJSRuntime jSRuntime { get; set; }

        [Inject] private CartHelper cartHelper { get; set; }


        private List<CartDetail> cartDetails = new();


        protected async override void OnInitialized()            
        {
            await jSRuntime.InvokeVoidAsync("addEventCart", DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public void UpdateCart(string _cartDetails)
        {
            if (!string.IsNullOrEmpty(_cartDetails))
            {
                var list = JsonConvert.DeserializeObject<List<CartDetail>>(_cartDetails);
                cartDetails = list;
            }
            StateHasChanged();
        }
        private async Task DeleteCart(Guid id)
        {

            await cartHelper.DeleteCartAsync(id);
        }

    }
}
