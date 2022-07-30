using ASM.SEVER.HttpInterfaces;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SEVER.Pages.Product
{
    public partial class Index
    {
        private bool DetailModalOpen = false;
        private bool DeleteModalOpen = false;
        private bool CreateModalOpen = false;
        private bool EditModalOpen = false;

        private string nameDelete;

        private object idDelete;


        private ASM.SHARE.Entities.Product ProductEdit;



        private ASM.SHARE.Entities.Product ProductDetail;




        private List<ASM.SHARE.Entities.Product> products;

        [Inject]
        private IProductHttp productHttpRepo { get; set; }



        [Inject]
        private IToastService toastService { get; set; }

        protected override async Task OnInitializedAsync()
        {

            await LoadData();
        }

        private async Task LoadData()
        {
            products = await productHttpRepo.GetProductsAsync();
        }


        //modal detail 
        private void OnDetailModalClose(bool acceped)
        {
            DetailModalOpen = false;
            StateHasChanged();
        }

        private void OpenDetailModal(ASM.SHARE.Entities.Product product)
        {
            DetailModalOpen = true;
            ProductDetail = product;
            StateHasChanged();
        }

        //modal delete 
        private async Task OnDeleteModalClose(bool acceped)
        {
            if (acceped)
            {
                var result = await productHttpRepo.DeleteAsync((Guid)idDelete);
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

        private void OpenDeleteModal(ASM.SHARE.Entities.Product productDelete)
        {
          
                DeleteModalOpen = true;
                idDelete = productDelete.ProductId;
                nameDelete = productDelete.Name;
                StateHasChanged();

        }

        // modal Create 

        private async void OnCreateModalClose(bool success)
        {
            if (success)
            {
                await LoadData();
            }
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

        private void OpenEditModal(ASM.SHARE.Entities.Product product)
        {
            EditModalOpen = true;
            ProductEdit = product;
            StateHasChanged();
        }
    }
}
