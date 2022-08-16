using ASM.CLIENT.HttpInterfaces;
using ASM.SHARE.Dtos.Account;
using ASM.SHARE.Dtos.Token;
using ASM.SHARE.Extensions;
using ASM.SHARE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASM.CLIENT.HttpRepository
{
    public class AccountHttpRepository : IAccountHttp
    {
        private readonly HttpClient client;

        public AccountHttpRepository(HttpClient client)
        {
            this.client = client;
        }

        public async Task<TokenResponse> Login(LoginDto loginDto)
        {
            var result = await client.PostAsync("https://localhost:5001/api/Token", loginDto.ToJsonBody());
            var finalData = await result.Content.ReadAsStringAsync();
            var _dataResponse = JsonConvert.DeserializeObject<TokenResponse>(finalData);
            return _dataResponse;
        }
    }
}
