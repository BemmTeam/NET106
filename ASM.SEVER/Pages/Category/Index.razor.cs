using System.Collections.Generic;
using System.Threading.Tasks;
using ASM.SEVER.HttpInterfaces;
using ASM.SHARE.Entities;
using Microsoft.AspNetCore.Components;

namespace ASM.SEVER.Pages.Category
{
    public partial class Index
    {
        private bool CreateModalOpen = false;  

        private List<ASM.SHARE.Entities.Category> categories = new();

        [Inject]
        private ICategoryHttp categoryHttpRepo { get; set; }

        protected override async Task OnInitializedAsync()
        {
             categories = await categoryHttpRepo.GetCategoriesAsync();
        }


        //modal 
        private void OnCreateModalClose(bool acceped)
        {
            CreateModalOpen = false;
            StateHasChanged();
        }



    }
}
