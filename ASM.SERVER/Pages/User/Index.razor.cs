
using ASM.SERVER.Helper;
using ASM.SERVER.HttpInterfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ASM.SERVER.Pages.User
{

    public partial class Index
    {
        private bool DetailModalOpen = false;
        private bool DeleteModalOpen = false;
        private bool CreateModalOpen = false;
        private bool EditModalOpen = false;

        private string nameDelete;

        private object idDelete;

        private ASM.SHARE.Entities.User UserEdit;



        private ASM.SHARE.Entities.User UserDetail;




        private List<ASM.SHARE.Entities.User> users;

        [Inject]
        private IUserHttp userHttpRepo { get; set; }

        [Inject]
        private ToastHelper toastService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            users = await userHttpRepo.GetUsersAsync();
        }


        //modal detail 
        private void OnDetailModalClose(bool acceped)
        {
            DetailModalOpen = false;
            StateHasChanged();
        }

        private void OpenDetailModal(ASM.SHARE.Entities.User user)
        {
            DetailModalOpen = true;
            UserDetail = user;
            StateHasChanged();
        }

        //modal delete 
        private async Task OnDeleteModalClose(bool acceped)
        {
            if (acceped)
            {
                var result = await userHttpRepo.DeleteAsync((Guid)idDelete);
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

        private void OpenDeleteModal(ASM.SHARE.Entities.User userDelete)
        {
            if (userDelete.IsAdmin)
                toastService.ShowError("Tài khoản Admin là không được xóa");
            else
            {
                DeleteModalOpen = true;
                idDelete = userDelete.UserId;
                nameDelete = userDelete.FullName;
                StateHasChanged();
            }

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

        private void OpenEditModal(ASM.SHARE.Entities.User user)
        {
            EditModalOpen = true;
            UserEdit = user;
            StateHasChanged();
        }

    }
}
