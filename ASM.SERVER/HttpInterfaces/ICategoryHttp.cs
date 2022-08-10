using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SERVER.HttpInterfaces
{
    public interface ICategoryHttp
    {
        Task<DataJsonResult> CreateAsync(CategoryDto category);

        Task<DataJsonResult> UpdateAsync(int id, CategoryDto category);

        Task<DataJsonResult> DeleteAsync(int categoryId);

        Task<Category> GetByIdAsync(int categoryId);

        Task<List<Category>> GetCategoriesAsync();
    }
}
