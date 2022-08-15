using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Interfaces;
using ASM.SHARE.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory categoryRepo;

        private readonly IMapper maper;

        public CategoryController(ICategory categoryRepo, IMapper maper)
        {
            this.categoryRepo = categoryRepo;
            this.maper = maper;
        }

        [HttpGet]

        public async Task<IActionResult> Categories()
        {
            var categories = await categoryRepo.GetCategoriesAsync();
            if (categories.Count > 0 && categories != null)
            {
                return Ok(new DataJsonResult
                {
                    IsSuccess = true,
                    Message = "Lấy danh sách danh mục thành công",
                    Data = categories
                });
            }
            return Ok(new DataJsonResult
            {
                IsSuccess = false,
                Message = "Không lấy được danh sách danh mục"
            });

        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> CategoryById(int? id)
        {
            if (id == null) return BadRequest("Không tìm thấy Id");

            var category = await categoryRepo.GetByIdAsync((int)id);
            if (category != null)
            {
                return Ok(new DataJsonResult
                {
                    IsSuccess = true,
                    Message = "Lấy danh mục thành công ",
                    Data = category
                });
            }

            return Ok(new DataJsonResult
            {
                IsSuccess = false,
                Message = "Lấy danh mục thất bại ",
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto category)
        {
            if (category == null) return BadRequest("Dữ liệu không đúng");

            var isSuccess = await categoryRepo.CreateAsync(maper.Map<Category>(category));
            if (isSuccess)
            {
                return Ok(new DataJsonResult
                {
                    IsSuccess = true,
                    Message = "Thêm danh mục thành công !",
                    Data = category
                });
            }

            return Ok(new DataJsonResult
            {
                IsSuccess = false,
                Message = "Thêm danh mục thất bại ",
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryDto category, int? id)
        {
            if (category == null || id == null) return BadRequest("Dữ liệu không đúng");

            var isSuccess = await categoryRepo.UpdateAsync((int)id, maper.Map<Category>(category));
            if (isSuccess)
            {
                return Ok(new DataJsonResult
                {
                    IsSuccess = true,
                    Message = "Cập nhật danh mục thành công !",
                    Data = category
                });
            }

            return Ok(new DataJsonResult
            {
                IsSuccess = false,
                Message = "Cập nhật danh mục thất bại ",
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var isSuccess = await categoryRepo.DeleteAsync(id);
            if (isSuccess) return Ok(new DataJsonResult { IsSuccess = true, Message = "Xóa danh mục thành công" });

            return Ok(new DataJsonResult { IsSuccess = false, Message = "Xóa danh mục thất bại" });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SeedData()
        {
            var listCategory = new MockCategory().GetCategories();

            var result = await categoryRepo.CreateManyAsync(listCategory);

            return Ok(new DataJsonResult { IsSuccess = result });
        }
    }
}
