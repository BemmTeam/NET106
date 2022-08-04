using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Interfaces;
using ASM.SHARE.Models;
using AutoMapper;
using Dropbox.Api;
using Dropbox.Api.Files;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProduct productRepository;
        private readonly IWebHostEnvironment environment;
        private readonly IMapper mapper;

        public ProductController(IProduct productRepository, IWebHostEnvironment environment, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.environment = environment;
            this.mapper = mapper;
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
            Product prd = mapper.Map<Product>(productDto);
            var result = await productRepository.CreateAsync(prd);

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



        //[httppost("[action]")]
        //public async task<iactionresult> uploadfile()
        //{
        //    var file = request.form.files[0];
        //    console.writeline("file nó  null né " );

        //    if (file != null)
        //    {
        //        console.writeline("file nó không null né " + file.name);
        //        try
        //        {
        //            var filename = guid.newguid().tostring().substring(0,5) + datetime.today.tostring("ddmm") + "." + path.getextension(file.filename);
        //            var filepath = path.combine(environment.contentrootpath, "files", "products", filename);
                   
        //            using var filestream = new filestream(filepath, filemode.create);
        //            await file.copytoasync(filestream);
        //            return ok(new datajsonresult { issuccess = true , message = "upload file thành công !" , data = filename});
        //        }
        //        catch
        //        {
        //            return ok(new datajsonresult { issuccess = true, message = "upload file thất bại !" });

        //        }
        //    }
        //    return ok(new datajsonresult { issuccess = false, message = "upload file thất bại !" });

        //}

       


        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var isSuccess = await productRepository.DeleteAsync(id);
            if (isSuccess) return Ok(new DataJsonResult { IsSuccess = true, Message = "Xóa sản phẩm thành công" });

            return Ok(new DataJsonResult { IsSuccess = false, Message = "Xóa sản phẩm thất bại" });
        }



    }
}
