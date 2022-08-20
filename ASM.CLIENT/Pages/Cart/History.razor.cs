using ASM.CLIENT.Helper;
using ASM.CLIENT.HttpInterfaces;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.CLIENT.Pages.Cart
{
    public partial class History
    {
        [Inject] private ICartHttp cartHttp { get; set; }
        [Inject] private IProductHttp productHttp { get; set; }

        [Inject] private ICartDetailHttp cartDetailHttp { get; set; }

        [Inject] private AccountHelper accountHelper { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private ToastHelper toastHelper { get; set; }

        private List<ASM.SHARE.Entities.Cart> carts = new();
        [Parameter]
        public string Id { get; set; }




        protected async override Task OnInitializedAsync()
        {

            var userId = Guid.Parse(Id);
            if (userId == Guid.Empty)
            {
                navigationManager.NavigateTo("/login");
                toastHelper.ShowInfo("Vui lòng đăng nhập");
            }


            var result = await cartHttp.GetListByUserId(userId);

            if (result.IsSuccess)
            {
                carts = JsonConvert.DeserializeObject<List<ASM.SHARE.Entities.Cart>>(result.Data.ToString());
                //foreach (var cart in carts)
                //{
                //    if (cart  != null)
                //    {
                //        var cartDetails = await cartDetailHttp.GetCartByCartId(cart.CartId);
                     
                //        foreach (var detl in cartDetails)
                //        {
                //            detl.Product = await productHttp.GetProduct(detl.ProductId);
                //        }
                //        cart.CartDetails = cartDetails;
                //    }
                //}
              
            }
            else
            {
                navigationManager.NavigateTo("/");
                toastHelper.ShowInfo("Không lấy được lịch sử đơn hàng");
            }
        }
    }
}
