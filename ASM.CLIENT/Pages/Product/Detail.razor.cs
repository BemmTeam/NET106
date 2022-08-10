using ASM.CLIENT.Helper;
using ASM.CLIENT.HttpInterfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.CLIENT.Pages.Product
{
    public partial class Detail
    {
        [Parameter]
        public string Id { get; set; }

        [Inject] private IProductHttp productHttp { get; set; }
        [Inject] private ToastHelper toastHelper { get; set; }


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
    }
}
