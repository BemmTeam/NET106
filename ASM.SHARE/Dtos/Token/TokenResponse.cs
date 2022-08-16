using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.SHARE.Dtos.Token
{
    public class TokenResponse
    {

        public bool IsSuccess { get; set; }

        public string Message { get; set; } 

        public string Token { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
