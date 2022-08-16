using ASM.SHARE.Dtos.Account;
using ASM.SHARE.Dtos.Token;
using ASM.SHARE.Entities;
using ASM.SHARE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.CLIENT.HttpInterfaces
{
    public interface IAccountHttp
    {

        Task<TokenResponse> Login(LoginDto loginDto);
    }
}
