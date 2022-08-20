using ASM.SHARE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartDetailController : Controller
    {
        private readonly ICartDetail cartDetailRepository;

        public CartDetailController(ICartDetail cartDetailRepository)
        {
            this.cartDetailRepository = cartDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CartDetail()
        {
            return Ok( await  cartDetailRepository.GetCartDetailsAsync());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CartDetailByCartId(Guid id)
        {
            return Ok(await cartDetailRepository.GetCartDetailByCartIdAsync(id));
        }
    }
}
