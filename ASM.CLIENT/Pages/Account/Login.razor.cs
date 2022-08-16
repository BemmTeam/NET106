using ASM.CLIENT.Helper;
using ASM.CLIENT.HttpInterfaces;
using ASM.SHARE.Dtos.Account;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.CLIENT.Pages.Account
{
    
    public partial class Login
    {


        private LoginDto login = new LoginDto();
     

        [Inject] private IAccountHttp accountHttp { get; set; }
        [Inject] private ToastHelper toastHelper { get; set; }

        [Inject] private AccountHelper accountHelper { get; set; }


        private async Task LoginAccount()
        {
         
            var result = await accountHttp.Login(login);
            if (result.IsSuccess )
            {
                toastHelper.ShowSuccess(result.Message);
                await accountHelper.Login(result);
            }
            else
            {
                toastHelper.ShowError(result.Message);
            }
        }
    }
}
