using ASM.SHARE.Dtos;
using ASM.SHARE.Interfaces;
using ASM.SHARE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ASM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProduct productRepository;
        private readonly IWebHostEnvironment environment;

        public ProductController(IProduct productRepository, IWebHostEnvironment environment)
        {
            this.productRepository = productRepository;
            this.environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            return Ok(new DataJsonResult
            {
                IsSuccess = true,
                Message = "Lấy danh sách sản phẩm",
                Data = await productRepository.GetProductsAsync()
            }) ;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Product(Guid? id)
        {
            if (id == null) return BadRequest("Thiếu trường thông tin");

            var product = await productRepository.GetProductByIdAsync((Guid)id);

            if(product != null)
            {
                return Ok(new DataJsonResult
                {
                    IsSuccess = true,
                    Message = "Lấy thông tin sản phẩm",
                    Data =product
                });
            }

            return Ok(new DataJsonResult { IsSuccess = false, Message = "Lấy thông tin sản phẩm thất bại" });
           
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto productDto )
        {
            Console.WriteLine(productDto.Address);
            Console.WriteLine(productDto.CategoryId);

            if (productDto == null) return BadRequest("Thiếu trường thông tin");
            ;
            //var imageUrl = await UploadFileAsync(file);
            //if(imageUrl == null)
            //{
            //    return Ok(new DataJsonResult
            //    {
            //        IsSuccess = false,
            //        Message = "Không upload được hình ảnh !",
            //    });
            //}

            //productDto.ImageUrl = imageUrl;
            var result = await productRepository.CreateAsync(productDto);

            if(result)
            {
                return Ok(new DataJsonResult
                {
                    IsSuccess = true,
                    Message = "Thêm sản phẩm thành công",
                    Data = productDto
                });
            }


            return Ok(new DataJsonResult
            {
                IsSuccess = false,
                Message = "Thêm sản phẩm thất bại",
            });
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> UploadFile()
        {
            var file = Request.Form.Files[0];
            Console.WriteLine("file nó  null né " );

            if (file != null)
            {
                Console.WriteLine("file nó không null né " + file.Name);
                try
                {
                    var fileName = Guid.NewGuid().ToString().Substring(0,5) + DateTime.Today.ToString("ddMM") + "." + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(environment.ContentRootPath, "Files", "Products", fileName);
                   
                    using var filestream = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(filestream);
                    return Ok(new DataJsonResult { IsSuccess = true , Message = "Upload file thành công !" , Data = fileName});
                }
                catch
                {
                    return Ok(new DataJsonResult { IsSuccess = true, Message = "Upload file thất bại !" });

                }
            }
            return Ok(new DataJsonResult { IsSuccess = false, Message = "Upload file thất bại !" });

        }
    }
}
