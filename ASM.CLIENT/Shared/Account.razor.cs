using ASM.CLIENT.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.CLIENT.Shared
{
    public partial class Account
    {

        [Inject] private IJSRuntime jsRuntime { get; set; }
        [Inject] private AccountHelper accountHelper { get; set; }
        private string name;
        private Guid userId;
        private bool isLogin;




        protected async override Task OnInitializedAsync()
        {
            var obj = DotNetObjectReference.Create(this);
            await jsRuntime.InvokeVoidAsync("addEventAccount", obj);
            isLogin = await accountHelper.IsLogin();
            if (isLogin)
            {
                name = await accountHelper.GetName();
                userId = await accountHelper.GetUserId();
            }

        }



        [JSInvokable]
        public async Task CheckLogin()
        {
            isLogin = await accountHelper.IsLogin();

            if (isLogin)
            {
                name = await accountHelper.GetName();
            }
            StateHasChanged();
        }

    }
}
