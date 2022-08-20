using ASM.CLIENT.Helper;
using ASM.CLIENT.HttpInterfaces;
using ASM.SHARE.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.CLIENT.Pages.Cart
{
    public partial class Index
    {

        [Inject] private CartHelper cartHelper { get; set; }

        [Inject] private AccountHelper accountHelper { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }


        [Inject] private ICartHttp cartHttp { get; set; }

        [Inject] private ToastHelper toastHelper { get; set; }


        private List<ASM.SHARE.Entities.CartDetail> cartDetails = new();

        private string Address;

        private float Total;
        protected async override Task OnInitializedAsync()
        {
            cartDetails = await cartHelper.GetListCartAsync();
            cartDetails.ForEach(item => {
                item.Total = item.Price * item.Quantity;
            });
            Total = cartDetails.Sum(p => p.Total);
        }

        private async Task CheckOut()
        {
            if (string.IsNullOrEmpty(Address))
            {
                toastHelper.ShowInfo("Vui lòng nhập địa chỉ nhận hàng");
                return;
            }

            var userId = await accountHelper.GetUserId();
            var cartS = cartDetails;
            cartS.ForEach(item => item.Product = null);
            CartDto cartDto = new CartDto()
            {
                Address = this.Address,
                CartDetails = cartS,
                UserId = userId,
                CreatedDate = DateTime.Now,
                Status = SHARE.Enum.StatusType.Shipping,
                Total = cartDetails.Sum(p => p.Total),
            };

            var result = await cartHttp.CreateAsync(cartDto);

            if (result.IsSuccess)
            {
                toastHelper.ShowSuccess(result.Message);
                cartDetails = new List<SHARE.Entities.CartDetail>();
                await cartHelper.ClearCartAsync();
                navigationManager.NavigateTo("/");
                StateHasChanged();
            }
            else toastHelper.ShowError("Không thanh toán được");
        }
    }
}
