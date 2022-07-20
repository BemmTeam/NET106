using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Interfaces;
using ASM.SHARE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUser userRepository;

        public UserController(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]

        public async Task<IActionResult> Users()
        {
            List<User> users =  await userRepository.GetUsersAsync();
            if(users != null)
            {
                return Ok(new DataJsonResult { IsSuccess = true, Message = "Lấy danh sách thành công", Data = users });

            }
            return Ok(new DataJsonResult { IsSuccess = false, Message = "Lấy danh sách thất bại" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid? id)
        {
            if (id == null) return BadRequest("Thiếu trường Id");

            var user = await userRepository.GetByIdAsync((Guid)id);
            if(user != null)
            {
                return Ok(new DataJsonResult { IsSuccess = true, Message = "Lấy thông tin User thành công", Data = user });
            }
            return Ok(new DataJsonResult { IsSuccess = false, Message = "Không tìm thấy user" });
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            if (userDto == null) return BadRequest("Thiếu dữ liệu !"); 

            if(await userRepository.CheckValidUserAsync(userDto))
            {
                return Ok(new DataJsonResult { IsSuccess = false, Message = "Username hoặc Email đã tồn tại" });
            }

            var result = await userRepository.CreateAsync(userDto);

            if (result)
                return Ok(new DataJsonResult { IsSuccess = true, Message = "Thêm user thành công !", Data = userDto });
            return Ok(new DataJsonResult { IsSuccess = false, Message = "Thêm user thất bại" }); 
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(Guid id ,UserDto userDto)
        {
            if (userDto == null) return BadRequest("Thiếu trường thông tin"); 

            var result = await userRepository.UpdateAsync(id, userDto);

            if (result)
                return Ok(new DataJsonResult { IsSuccess = true, Message = "Cập nhật user thành công" });

            return Ok(new DataJsonResult { IsSuccess = false, Message = "Cập nhật user thất bại" });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id)
        {

             var isSuccess = await userRepository.DeleteAsync(id);
            if (isSuccess) return Ok(new DataJsonResult { IsSuccess = true, Message = "Xóa user thành công" });

            return Ok(new DataJsonResult { IsSuccess = false, Message = "Xóa user thất bại" });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = await userRepository.RegisterAsync(model);
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
