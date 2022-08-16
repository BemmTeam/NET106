using ASM.CLIENT.Helper;
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

        private void CheckOut()
        {
            Guid id = Guid.NewGuid();
            cartDetails.ForEach(item => {
                item.CartId = id;
            });
            CartDto cartDto = new CartDto()
            {
                Address = Address,
                CartDetails = cartDetails,

            };
        }
    }
}
