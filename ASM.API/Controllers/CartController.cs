using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Interfaces;
using ASM.SHARE.Models;
using ASM.SHARE.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICart cartRepository;
        private readonly IMapper maper; 
        [HttpPost]
        public async Task<IActionResult> CreateCart(CartDto cartDto)
        {
            if (cartDto == null) return BadRequest("Dữ liệu không đúng");

            var isSuccess = await cartRepository.CreateAsync(maper.Map<Cart>(cartDto));
            if (isSuccess)
            {
                return Ok(new DataJsonResult
                {
                    IsSuccess = true,
                    Message = "Thêm giỏ hàng thành công !",
                    Data = cartDto
                });
            }

            return Ok(new DataJsonResult
            {
                IsSuccess = false,
                Message = "Thêm giỏ hàng thất bại ",
            });
        }
    }
}
