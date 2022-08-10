using System.Collections.Generic;
using System.Threading.Tasks;
using ASM.SERVER.Helper;
using ASM.SERVER.HttpInterfaces;
using ASM.SHARE.Entities;

using Microsoft.AspNetCore.Components;

namespace ASM.SERVER.Pages.Category
{
    public partial class Index
    {
        private bool DetailModalOpen = false;
        private bool DeleteModalOpen = false;
        private bool CreateModalOpen = false;
        private bool EditModalOpen = false;

        private string nameDelete;

        private object idDelete;

        private ASM.SHARE.Entities.Category CategoryEdit;



        private ASM.SHARE.Entities.Category CategoryDetail;


        private List<ASM.SHARE.Entities.Category> categories;

        [Inject]
        private ICategoryHttp categoryHttpRepo { get; set; }

        [Inject]
        private ToastHelper toastService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            categories = await categoryHttpRepo.GetCategoriesAsync();
        }


        //modal detail 
        private void OnDetailModalClose(bool acceped)
        {
            DetailModalOpen = false;
            StateHasChanged();
        }

        private void OpenDetailModal(ASM.SHARE.Entities.Category category)
        {
            DetailModalOpen = true;
            CategoryDetail = category;
            StateHasChanged();
        }

        //modal delete 
        private async Task OnDeleteModalClose(bool acceped)
        {
            if (acceped)
            {
                var result = await categoryHttpRepo.DeleteAsync((int)idDelete);
                if (result.IsSuccess)
                {
                    toastService.ShowSuccess(result.Message);
                    await LoadData();
                }
                else
                    toastService.ShowError(result.Message);
            }
            DeleteModalOpen = false;
            StateHasChanged();
        }

        private void OpenDeleteModal(string name, object id)
        {
            DeleteModalOpen = true;
            idDelete = id;
            nameDelete = name;
            StateHasChanged();
        }

        // modal Create 

        private async void OnCreateModalClose(bool success)
        {
            if (success)
                await LoadData();
            CreateModalOpen = false;
            StateHasChanged();
        }

        private void OpenCreateModal()
        {
            CreateModalOpen = true;
            StateHasChanged();
        }


        // modal Edit 

        private async void OnEditModalClose(bool success)
        {
            if (success)
                await LoadData();
            EditModalOpen = false;
            StateHasChanged();
        }

        private void OpenEditModal(ASM.SHARE.Entities.Category category)
        {
            EditModalOpen = true;
            CategoryEdit = category;
            StateHasChanged();
        }

    }
}
