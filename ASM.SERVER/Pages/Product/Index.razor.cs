using ASM.SERVER.Helper;
using ASM.SERVER.HttpInterfaces;
using ASM.SHARE.Helper;
using Microsoft.AspNetCore.Components;
using Smart.Blazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SERVER.Pages.Product
{
    public partial class Index
    {
        private bool DetailModalOpen = false;
        private bool DeleteModalOpen = false;
        private bool CreateModalOpen = false;
        private bool QrCodeModalOpen = false;

        private bool EditModalOpen = false;

        private string nameDelete;
        private string pathDelete;

        private string host;
        private string dataImage;


        private object idDelete;


        private ASM.SHARE.Entities.Product ProductEdit;



        private ASM.SHARE.Entities.Product ProductDetail;


        private ASM.SHARE.Dtos.PagingProductDto Paging = new();


        private List<ASM.SHARE.Entities.Product> products;

        [Inject]
        private IProductHttp productHttpRepo { get; set; }


        [Inject]
        private NavigationManager navigationManager { get; set; }

        [Inject]
        private ToastHelper toastService { get; set; }

        [Inject]
        private QRcodeHelper qRCodeHelper { get; set; }

        private string stringSearch { get; set; }
        protected override async Task OnInitializedAsync()
        {
            host = navigationManager.BaseUri + "Product/";
            await LoadData();
        }

        private async Task LoadData()
        {
            Paging = await productHttpRepo.GetListProductWithThumbImage(Paging);
            products = Paging.Data;
            StateHasChanged();
        }

        private async Task LoadDataPage(int pageSeleced)
        {
            products = null;
            Paging.PageSelected = pageSeleced;
            await LoadData();
        }

        //modal detail 
        private void OnDetailModalClose(bool acceped)
        {
            DetailModalOpen = false;
            StateHasChanged();
        }

        private void OpenDetailModal(ASM.SHARE.Entities.Product product)
        {
            product.QrCodeUrl = navigationManager.BaseUri + "Product/" + product.ProductId.ToString();
            DetailModalOpen = true;
            ProductDetail = product;
            StateHasChanged();
        }

        //modal delete 
        private async Task OnDeleteModalClose(bool acceped)
        {
            if (acceped)
            {

                var result = await productHttpRepo.DeleteAsync((Guid)idDelete, pathDelete);
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
            pathDelete = productDelete.ImageUrl;
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


        // onChange 

        private async Task OnChangeSearch(Event ev)
        {
            if (ev.ContainsKey("Detail"))
            {
                InputChangingEventDetail detail = ev["Detail"];
                Paging.Search = detail.OldValue;
                await LoadData();

            }

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



        //modal qrcode 
        private void OnQrCodeModalClose(bool acceped)
        {
            QrCodeModalOpen = false;
            StateHasChanged();
        }

        private void OpenQrCodeModal(Guid id)
        {
            var url = navigationManager.BaseUri + "Product/" + id.ToString();
            QrCodeModalOpen = true;
            dataImage = qRCodeHelper.GenerateQrCodeString(url);
            StateHasChanged();
        }
    }
}
