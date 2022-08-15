using ASM.CLIENT.Helper;
using ASM.CLIENT.HttpInterfaces;
using ASM.SHARE.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace ASM.CLIENT.Pages.Product
{
    public partial class Detail
    {
        [Parameter]
        public string Id { get; set; }

        [Inject] private IProductHttp productHttp { get; set; }
        [Inject] private ToastHelper toastHelper { get; set; }
        [Inject] private CartHelper cartHelper { get; set; }


        private ASM.SHARE.Entities.Product product;



        protected async override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                product = await productHttp.GetProduct(Guid.Parse(Id));
            }
            else
            {
                toastHelper.ShowError("Không tìm thấy sản phẩm nào !");
            }
        }
        private async Task AddToCart()
        {
            CartDetail cartDetailt = new CartDetail()
            {
                
                Product = product,
                ProductId = product.ProductId,
                Quantity = 1,
                Price = product.Price
            };
            await cartHelper.InsertCartAsync(cartDetailt);
        }


      

    }
}
