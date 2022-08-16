using ASM.SHARE.Dtos.Token;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.CLIENT.Helper
{
    public class AccountHelper
    {
        private readonly IJSRuntime jsRuntime;

        public AccountHelper(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        } 


    
        public async Task Login(TokenResponse token)
        {
            await jsRuntime.InvokeVoidAsync("Account.Login", token.Id, token.Name, token.Token);
        }

        public async Task<bool> IsLogin()
        {
           return await jsRuntime.InvokeAsync<bool>("Account.IsLogin");
        }

        public async Task<Guid> GetUserId()
        {
            var result = await jsRuntime.InvokeAsync<string>("Account.GetUserId");
            var id = Guid.Parse(result);
            return id;
        }

        public async Task<string> GetName()
        {
            var result = await jsRuntime.InvokeAsync<string>("Account.GetName");
            return result;
        }

        public async Task<string> GetToken()
        {
            var result = await jsRuntime.InvokeAsync<string>("Account.GetToken");
            return result;
        }
    }
}
