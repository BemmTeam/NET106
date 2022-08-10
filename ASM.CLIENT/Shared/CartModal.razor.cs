using ASM.CLIENT.Helper;
using ASM.SHARE.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASM.CLIENT.Shared
{
    public partial class CartModal
    {
        [Inject] private CartHelper cartHelper { get; set; }

        private List<CartDetail> cartDetails = new();
        protected override void OnInitialized()
        {
            cartHelper.OnChange += CartHelper_OnChange; 
        }

        private void CartHelper_OnChange()
        {
            cartDetails = cartHelper.CartDetails;
            StateHasChanged();
        }

        public void Dispose()
        {
            cartHelper.OnChange -= StateHasChanged;
        }
       
    }
}
