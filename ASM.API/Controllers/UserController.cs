using ASM.SHARE.Interfaces;
using ASM.SHARE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASM.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUser userRepository;

        public UserController(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = await userRepository.Register(model);
            if(user != null)
            {
                return Ok(new DataJsonResult
                {
                    IsSuccess = true,
                    Message = "Đăng ký thành công",
                    Data = user
                }) ;
            }
            return Ok(new DataJsonResult { IsSuccess = false , Message  = "Đăng ký không thành công"  });
        }
    }
}
