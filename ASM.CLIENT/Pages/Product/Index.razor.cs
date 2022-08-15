using ASM.CLIENT.HttpInterfaces;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.CLIENT.Pages.Product
{
    public partial class Index
    {

        [Inject] private IProductHttp productHttp { get; set; }


        [Inject] private ICategoryHttp categoryHttp { get; set; }


        private List<ASM.SHARE.Entities.Product> products = new();

        private List<ASM.SHARE.Entities.Category> categories = new();

        private ASM.SHARE.Dtos.PagingProductDto Paging = new();


        protected override async Task OnInitializedAsync()
        {
            Paging.PageSize = 10;

            categories = await categoryHttp.GetCategories();
            await LoadProductAsync();
        }

        private async Task LoadProductAsync()
        {
            Paging = await productHttp.GetListProductWithThumbImage(Paging);
            products = Paging.Data;
        }

        private async void ToPage(int select)
        {
            Paging.PageSelected = select;
            await LoadProductAsync();
        }
    }
}
